using log4net;
using Microsoft.VisualBasic.FileIO;
using SIDfmContext;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using CSV列 = VulnDB.Const.CSV列;
using 入力規則 = VulnDB.Const.入力規則;

namespace VulnDB
{
    /// <summary>
    /// csvを読む
    /// dbに保存する
    /// </summary>
    class SIDfmCsvRegister
    {
        readonly log4net.ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        internal void doRegist(string s)
        {
            try
            {
                using (
                TextFieldParser file = new TextFieldParser(s, Encoding.GetEncoding(932))
                {
                    TextFieldType = FieldType.Delimited,    //フィールドが文字で区切られているとする
                    Delimiters = new string[] { "," },      //区切り文字を,とする
                    HasFieldsEnclosedInQuotes = true,       //フィールドを"で囲み、改行文字、区切り文字を含める
                    TrimWhiteSpace = true                   //フィールドの前後からスペースを削除する
                }
                )
                using (SIDfmEntities en = new SIDfmEntities())
                {
                    SIDfm obj;          // 現在のオブジェクト
                    SIDfm objBefore;    // 変更前のオブジェクト
                    string[] csvFields; // CSVの列（カンマ分割後）
                    SIDfmForm form;     // カンマ区切りのデータをセットしたform
                    int csv行番号 = 0;   // CSVファイルの行番号

                    int SIDfmId;
                    string CVE番号;
                    Dictionary<string,string> 対象製品名 = new Dictionary<string,string>();

                    ErrorOfForm errorOfLine;      // 書式エラーの格納
                    ErrorOfAll errorOfAll = new ErrorOfAll();
                    //Dictionary<int,ErrorsByForm> errorDic = new Dicionary<int,ErrorsByForm>();   // 書式エラーの格納（全行分）

                    // csvファイルを1行ずつ読み込み
                    while (!file.EndOfData)
                    {
                        csvFields = file.ReadFields();
                        csv行番号++;

                        // 製品名が入っている見出し行
                        if (isItemLine(csvFields))
                        {
                            //csvFields.CopyTo(itemNameFields = new string[csvFields.Length], 0);
                            for (int i = (int)CSV列.アイテム1; i < csvFields.Length; i++)
                            {
                                // 製品名のセット
                                // CSVに入っている対象製品名がリソースマスタに登録されていたら、
                                // 表示用の短縮名をセット。登録されていなかったらCSVの名称をセット。
                                // 通常はリソースマスタに未登録の製品名が来ることはないが、
                                // ・脆弱性情報の収集対象を変更するために、フィルタの追加削除を行った場合
                                // ・SIDfm側の仕様変更
                                // などの理由で来る場合があるかも。
                                var midashi = en.Resource.Where(x => x.対象製品名 == csvFields[i]);
                                if (midashi.Count() == 0)
                                {   // なければCSVのテキストを登録
                                    対象製品名[csvFields[i]] = csvFields[i];
                                }
                                else
                                {   // あれば見出し名を登録
                                    対象製品名[csvFields[i]] = midashi.First().対象製品見出し名;
                                }
                            }
                        }
                        // 先頭列が数値の行を「データ行」として扱う。
                        else if (isDataLine(csvFields))
                        {
                            // フォームの中で必須条件と書式のチェックを行う
                            form = new SIDfmForm(csvFields);
                            // 1行分の内容をチェック
                            errorOfLine = form.validate(csv行番号);
                            // この行にエラーがあったらこの行を飛ばして次に移動
                            if (errorOfLine.hasError())
                            {
                                continue;
                            }

                            SIDfmId = Int32.Parse(csvFields[(int)CSV列.SIDfmId]);
                            CVE番号 = csvFields[(int)CSV列.CVE番号];
                            // データ行なら処理を継続
                            // SIDfmId＋CVE番号が一意キーなので、同じデータが登録済の場合は上書きする。
                            // データがあったら更新
                            // データが無ければ新規作成
                            var rowdata = en.SIDfm.Where(x => x.SIDfmId == SIDfmId && x.CVE番号 == CVE番号);

                            // データが0件⇒新規
                            if (rowdata.Count() == 0)
                            {
                                obj = new SIDfm();
                                // SIDfmIdとCVE番号はキー項目なので新規の場合のみセットする
                                obj.SIDfmId = SIDfmId;
                                obj.CVE番号 = CVE番号;
                                obj.INSERT_DATE = DateTime.Now;
                                en.SIDfm.Add(obj);
                            }
                            else
                            {
                                obj = rowdata.First();
                            }

                            objBefore = Util.deepCopy(obj);

                            // 新規、更新共通の更新
                            obj.タイトル = csvFields[(int)CSV列.タイトル];
                            if (!String.IsNullOrEmpty(csvFields[(int)CSV列.CVSS基本値]))
                            {
                                obj.CVSS基本値 = Convert.ToDecimal(csvFields[(int)CSV列.CVSS基本値]);
                            }

                            // この3区分は通常いづれか1つだけが「1」で、それ以外は「0」が入っている。
                            // ただし、CVSS基準値が未設定の場合は値が入っていない状態になる
                            // 攻撃元
                            obj.攻撃元 = setValue(
                                csvFields[(int)CSV列.攻撃元_ローカル],
                                csvFields[(int)CSV列.攻撃元_隣接],
                                csvFields[(int)CSV列.攻撃元_ネットワーク]);

                            // 攻撃成立条件
                            obj.攻撃成立条件 = setValue(
                               csvFields[(int)CSV列.攻撃成立条件_難しい],
                               csvFields[(int)CSV列.攻撃成立条件_やや難],
                               csvFields[(int)CSV列.攻撃成立条件_簡単]);

                            // 攻撃前の認証
                            obj.攻撃前の認証 = setValue(
                               csvFields[(int)CSV列.攻撃前の認証_複数],
                               csvFields[(int)CSV列.攻撃前の認証_単一],
                               csvFields[(int)CSV列.攻撃前の認証_不要]);

                            // 情報漏えい
                            obj.情報漏えい = setValue(
                               csvFields[(int)CSV列.情報漏えい_影響無し],
                               csvFields[(int)CSV列.情報漏えい_部分的],
                               csvFields[(int)CSV列.情報漏えい_全面的]);

                            // 情報改ざん
                            obj.情報改ざん = setValue(
                                csvFields[(int)CSV列.情報改ざん_影響無し],
                                csvFields[(int)CSV列.情報改ざん_部分的],
                                csvFields[(int)CSV列.情報改ざん_全面的]);

                            // 業務停止
                            obj.業務停止 = setValue(
                               csvFields[(int)CSV列.業務停止_影響無し],
                               csvFields[(int)CSV列.業務停止_部分的],
                               csvFields[(int)CSV列.業務停止_全面的]);

                            if (!String.IsNullOrEmpty(csvFields[(int)CSV列.攻撃コードの有無]))
                            {
                                obj.攻撃コードの有無 = Int32.Parse(csvFields[(int)CSV列.攻撃コードの有無]);
                            }
                            if (!String.IsNullOrEmpty(csvFields[(int)CSV列.情報登録日]))
                            {
                                obj.情報登録日 = DateTime.Parse(csvFields[(int)CSV列.情報登録日]);
                            }

                            // ここから、対象製品＋登録日
                            //items = csvFields.Skip((int)(CSV列.情報登録日 + 1)).Take((int)csvFields.Count() - (int)CSV列.情報登録日).ToArray();
                            // 列数分まわる
                            for (int i = (int)CSV列.アイテム1; i < csvFields.Length; i++)
                            {
                                // 対象製品パッチ登録日が入っている場合
                                if (!String.IsNullOrEmpty(csvFields[i]))
                                {
                                    obj.対象製品名 = Util.setMultiRow2SingleColumn(obj.対象製品名, 対象製品[itemNameFields[i]]);
                                    obj.対象製品パッチ登録日 = Util.setMultiRow2SingleColumn(obj.対象製品パッチ登録日, csvFields[i]);
                                }
                            }
                            // データが変更されていたら更新日を入れて変更反映。
                            // 変更がない場合はDBに書き込みしない
                            if (isChange(objBefore, obj))
                            {
                                obj.UPDATE_DATE = DateTime.Now;
                                en.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e.ToString());
                throw;
            }
        }

        // データ行は先頭列が数値の場合は正常なものと識別する
        bool isDataLine(string[] ss)
        {
            int dummy;
            return Int32.TryParse(ss[0], out dummy);
        }
        bool isNotDataLine(string[] ss)
        {
            return isDataLine(ss) ? false : true;
        }
        bool isItemLine(string[] ss)
        {
            return ss[0] == "ID";
        }
        int setValue(string v1, string v2, string v3)
        {
            int i1, i2, i3, r;
            i1 = Int32.TryParse(v1, out r) ? Int32.Parse(v1) : 0;
            i2 = Int32.TryParse(v2, out r) ? Int32.Parse(v2) * 10 : 0;
            i3 = Int32.TryParse(v2, out r) ? Int32.Parse(v3) * 100 : 0;
            return i1 + i2 + i3;
        }
        bool isChange(SIDfm before, SIDfm after)
        {
            // 更新時の項目だけを確認するので、
            // IDやINSERT_DATEは対象外
            // obj.SIDfmId = SIDfmId;
            // obj.CVE番号 = CVE番号;
            // obj.INSERT_DATE = DateTime.Now;
            if (before.タイトル != after.タイトル) return true;
            if (before.CVSS基本値 != after.CVSS基本値) return true;
            if (before.攻撃元 != after.攻撃元) return true;
            if (before.攻撃成立条件 != after.攻撃成立条件) return true;
            if (before.攻撃前の認証 != after.攻撃前の認証) return true;
            if (before.情報漏えい != after.情報漏えい) return true;
            if (before.情報改ざん != after.情報改ざん) return true;
            if (before.業務停止 != after.業務停止) return true;
            if (before.攻撃コードの有無 != after.攻撃コードの有無) return true;
            if (before.情報登録日 != after.情報登録日) return true;
            if (before.対象製品名 != after.対象製品名) return true;
            if (before.対象製品パッチ登録日 != after.対象製品パッチ登録日) return true;

            return false;
        }
    }
}