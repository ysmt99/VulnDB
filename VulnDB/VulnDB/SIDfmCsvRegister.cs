using log4net;
using Microsoft.VisualBasic.FileIO;
using SIDfmContext.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;
using CSV列 = VulnDB.Const.CSV列;

namespace VulnDB
{
    /// <summary>
    /// csvを読む
    /// dbに保存する
    /// </summary>
    class SIDfmVulnCsvRegister
    {
        struct 取込結果
        {
            public int csv行番号;          // CSVファイルの行番号
            public int 商品件数;            // csvファイル内の商品情報の件数
            public int 登録件数_新規;     // 正常に登録できた件数（新規）
            public int 登録件数_更新;     // 更新した件数
            public int 登録件数_未変更;    // 変更がないので登録しなかった件数
            public int エラー件数;
            public int 見出し件数;
            public DateTime 処理開始日時;
            public DateTime 処理終了日時;
        }
        readonly log4net.ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        internal List<string> doRegist(string s)
        {
            try
            {
                取込結果 取込結果 = new 取込結果();
                List<string> 実行結果 = new List<string>();
                Dictionary<int, string> 対象製品名 = new Dictionary<int, string>();
                ErrorOfForm errorOfLine;      // 書式エラーの格納
                int 行数 = 0;
                Func<Func<string[], bool>, bool> readCsvFunc = new Func<Func<string[], bool>, bool>(readFunc =>
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
                    {
                        while (!file.EndOfData)
                        {
                            if (!readFunc(file.ReadFields()))
                                return false;
                        }
                        return true;
                    }
                });

                logger.Info("＝＝＝＝＝＝＝＝＝＝＝処理開始＝＝＝＝＝＝＝＝＝＝＝");
                logger.Info(String.Format("ファイル名：{0}", s));
                取込結果.処理開始日時 = DateTime.Now;
                readCsvFunc(new Func<string[], bool>(values =>
                {
                    行数++;
                    return true;
                }));
                if (行数 <= 0)
                {
                    return 実行結果;
                }

                using (cmdbEntities en = new cmdbEntities())
                {
                    readCsvFunc(new Func<string[], bool>(csvFields =>
                    {
                        SIDfmVuln obj;          // 現在のオブジェクト
                        SIDfmVuln objBefore;    // 変更前のオブジェクト
                        SIDfmVulnForm form;     // カンマ区切りのデータをセットしたform

                        int SIDfmVulnId;
                        string CVE番号;

                        progressCountUp(1, 行数);

                        取込結果.csv行番号++;

                        // 製品名が入っている見出し行
                        if (isItemLine(csvFields))
                        {
                            取込結果.見出し件数++;
                            //csvFields.CopyTo(itemNameFields = new string[csvFields.Length], 0);
                            for (int i = (int)CSV列.アイテム1; i < csvFields.Length; i++)
                            {
                                // 製品名のセット
                                // CSVに入っている対象製品名がリソースマスタに登録されていたら、
                                // 表示用の短縮名をセット。登録されていなかったらCSVの名称をセット。
                                // 通常はリソースマスタに未登録の製品名が来ることはないが、
                                // ・脆弱性情報の収集対象を変更するために、フィルタの追加削除を行った場合
                                // ・SIDfmVuln側の仕様変更
                                // などの理由で来る場合があるかも。
                                string name = csvFields[i];
                                対象製品名[i] = en.SIDfmSoftware
                                    .Where(x => x.対象製品名 == name) 
                                    .Select( x=>x.対象製品短縮名)
                                    .FirstOrDefault() ?? name;
                            }
                        }
                        // 先頭列が数値の行を「データ行」として扱う。
                        else if (isDataLine(csvFields))
                        {
                            取込結果.商品件数++;
                            // フォームの中で必須条件と書式のチェックを行う
                            form = new SIDfmVulnForm(csvFields);
                            // 1行分の内容をチェック
                            errorOfLine = form.validate(取込結果.csv行番号);
                            // この行にエラーがあったらこの行を飛ばして次に移動
                            if (errorOfLine.hasError())
                            {
                                取込結果.エラー件数++;
                                writeLog(errorOfLine);
                                return true;
                            }

                            SIDfmVulnId = Int32.Parse(csvFields[(int)CSV列.SIDfmVulnId]);
                            CVE番号 = csvFields[(int)CSV列.CVE番号];
                            // データ行なら処理を継続
                            // SIDfmVulnId＋CVE番号が一意キーなので、同じデータが登録済の場合は上書きする。
                            // データがあったら更新
                            // データが無ければ新規作成
                            var rowdata = en.SIDfmVuln.Where(x => x.SIDfmVulnId == SIDfmVulnId && x.CVE番号 == CVE番号);

                            // データが0件⇒新規
                            if (rowdata.Count() == 0)
                            {
                                obj = new SIDfmVuln();
                                // SIDfmVulnIdとCVE番号はキー項目なので新規の場合のみセットする
                                obj.SIDfmVulnId = SIDfmVulnId;
                                obj.CVE番号 = CVE番号;
                                obj.INSERT_DATE = DateTime.Now;
                                en.SIDfmVuln.Add(obj);

                                取込結果.登録件数_新規++;
                            }
                            else
                            {
                                obj = rowdata.First();

                                取込結果.登録件数_更新++;
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
                                    obj.対象製品名 = Util.setMultiRow2SingleColumn(obj.対象製品名, 対象製品名[i]);
                                    obj.対象製品パッチ登録日 = Util.setMultiRow2SingleColumn(obj.対象製品パッチ登録日, csvFields[i]);
                                }
                            }
                            // データが変更されていたら更新日を入れて変更反映。
                            // 変更がない場合はDBに書き込みしない
                            if (isChange(objBefore, obj))
                            {
                                obj.UPDATE_DATE = DateTime.Now;
                                //en.SaveChanges();
                            }
                            else
                            {
                                取込結果.登録件数_更新--;
                                取込結果.登録件数_未変更++;
                            }
                        }
                        else
                        {
                            取込結果.見出し件数++;
                        }
                        return true;
                    }));

                    取込結果.処理終了日時 = DateTime.Now;
                    ActionLog actionLog = new ActionLog();
                    actionLog.アクション = (long)Const.アクション種類.CSV登録;
                    actionLog.処理開始日時 = 取込結果.処理開始日時;
                    actionLog.処理終了日時 = 取込結果.処理終了日時;
                    en.ActionLog.Add(actionLog);

                    //登録処理を実行。1件ずつCommitしないことで実行速度をあげる
                    en.SaveChanges();
                }

                実行結果.Add("＝＝＝＝＝＝＝＝＝＝＝処理結果＝＝＝＝＝＝＝＝＝＝＝");
                実行結果.Add(
                    String.Format("処理時間：{0} ({1}～{2})",
                        取込結果.処理終了日時.Subtract(取込結果.処理開始日時).ToString(@"hh\:mm\:ss"), 取込結果.処理開始日時, 取込結果.処理終了日時));
                実行結果.Add(String.Format("ファイル行数：{0}件", 取込結果.csv行番号));
                実行結果.Add(String.Format("登録失敗：{0}件", 取込結果.エラー件数));
                実行結果.Add(String.Format("登録成功：{0}件（新規{1}件、更新{2}件、変更なし{3}件）",
                    取込結果.登録件数_新規 + 取込結果.登録件数_更新 + 取込結果.登録件数_未変更, 取込結果.登録件数_新規, 取込結果.登録件数_更新, 取込結果.登録件数_未変更));
                実行結果.Add(String.Format("見出し行：{0}件", 取込結果.見出し件数));
                実行結果.Add("＝＝＝＝＝＝＝＝＝＝＝処理終了＝＝＝＝＝＝＝＝＝＝＝");

                実行結果.ForEach(err => logger.Info(err));

                return 実行結果;
            }
            catch (Exception e)
            {
                logger.Error(e.ToString());
                throw;
            }
           // return new List<string>(); 
        }

        // csvレコードは、先頭列が数値の場合を正常なデータ行として識別する
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
        bool isChange(SIDfmVuln before, SIDfmVuln after)
        {
            // 更新時の項目だけを確認するので、
            // IDやINSERT_DATEは対象外
            // obj.SIDfmVulnId = SIDfmVulnId;
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
        void writeLog(ErrorOfForm error)
        {
            foreach (string s in error.getErrorMessages())
            {
                logger.Info(s);
            }
        }
        public Action<int,int> progressCountUp;
    }












}