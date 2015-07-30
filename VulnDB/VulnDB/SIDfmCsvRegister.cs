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
using VulnDB.form;

namespace VulnDB
{
    /// <summary>
    /// csvを読む
    /// dbに保存する
    /// </summary>
    class SIDfmCsvRegister
    {
        readonly log4net.ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public enum CSV列 {
            SIDfmId,
            タイトル,
            CVE番号,
            CVSS基本値,
            攻撃元_ローカル,
            攻撃元_隣接,
            攻撃元_ネットワーク,
            攻撃成立条件_難しい,
            攻撃成立条件_やや難,
            攻撃成立条件_簡単,
            攻撃前の認証_複数,
            攻撃前の認証_単一,
            攻撃前の認証_不要,
            情報漏えい_影響無し,
            情報漏えい_部分的,
            情報漏えい_全面的,
            情報改ざん_影響無し,
            情報改ざん_部分的,
            情報改ざん_全面的,
            業務停止_影響無し,
            業務停止_部分的,
            業務停止_全面的,
            攻撃コードの有無,
            情報登録日,
            アイテム1,
            アイテム2,
            アイテム3,
            アイテム4,
            アイテム5,
            アイテム6,
            アイテム7,
            アイテム8,
            アイテム9,
            アイテム10
        };

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
                using ( SIDfmEntities en = new SIDfmEntities())
                {
                    SIDfm obj;
                    SIDfm baseObj;
                    //1行読んで列分割
                    string[] fields;
                    int SIDfmId;
                    string CVE番号;
                    Dictionary<string, string> 対象製品 = new Dictionary<string, string>();
                    string itemName;

                     // csvファイルを全行読み込み
                     while (!file.EndOfData)
                     {
                         fields = file.ReadFields();

                         // ヘッダー部分には説明文は対象のソフトウェア名などが入っている。
                         if (isItemLine(fields))
                         {
                            // 対象製品名を取得
                            itemName = fields[1];    
                            // 対象製品名をキーに対象製品見出し名を取得し、mapに格納
                            var midashi = en.Resource.Where(x => x.対象製品名 == itemName);
                            if (midashi.Count() == 0)
                            {
                                対象製品.Add(itemName, itemName);
                            }
                            else
                            {
                                対象製品.Add(itemName, midashi.First().対象製品見出し名);
                            }
                         }
                         // 先頭列が数値の行を「データ行」として扱う。
                         else if (isDataLine(fields))
                         {
                             SIDfmId = Int32.Parse(fields[(int)CSV列.SIDfmId]);
                             CVE番号 = fields[(int)CSV列.CVE番号];
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

                       //      baseObj = Util.deepCopy(obj);
                             baseObj = obj;

                             // 新規、更新共通の更新
                             obj.タイトル = fields[(int)CSV列.タイトル];
                             obj.CVSS基本値 = Convert.ToDecimal(fields[(int)CSV列.CVSS基本値]);

                             // この3区分は通常いづれか1つだけが「1」で、それ以外は「0」が入っている。
                             // ただし、CVSS基準値が未設定の場合は値が入っていない状態になる
                             // 攻撃元
                             obj.攻撃元 = setValue(
                                 fields[(int)CSV列.攻撃元_ローカル],
                                 fields[(int)CSV列.攻撃元_隣接],
                                 fields[(int)CSV列.攻撃元_ネットワーク]);

                             // 攻撃成立条件
                             obj.攻撃成立条件 = setValue(
                                fields[(int)CSV列.攻撃成立条件_難しい],
                                fields[(int)CSV列.攻撃成立条件_やや難],
                                fields[(int)CSV列.攻撃成立条件_簡単]);

                             // 攻撃前の認証
                             obj.攻撃前の認証 = setValue(
                                fields[(int)CSV列.攻撃前の認証_複数],
                                fields[(int)CSV列.攻撃前の認証_単一],
                                fields[(int)CSV列.攻撃前の認証_不要]);

                             // 情報漏えい
                             obj.情報漏えい = setValue(
                                fields[(int)CSV列.情報漏えい_影響無し],
                                fields[(int)CSV列.情報漏えい_部分的],
                                fields[(int)CSV列.情報漏えい_全面的]);

                             // 情報改ざん
                             obj.情報改ざん = setValue(
                                 fields[(int)CSV列.情報改ざん_影響無し],
                                 fields[(int)CSV列.情報改ざん_部分的],
                                 fields[(int)CSV列.情報改ざん_全面的]);

                             // 業務停止
                             obj.業務停止 = setValue(
                                fields[(int)CSV列.業務停止_影響無し],
                                fields[(int)CSV列.業務停止_部分的],
                                fields[(int)CSV列.業務停止_全面的]);
                             
                             obj.攻撃コードの有無 = Int32.Parse(fields[(int)CSV列.攻撃コードの有無]);
                             obj.情報登録日 = DateTime.Parse(fields[(int)CSV列.情報登録日]);

                             // ここから、対象製品＋登録日

                             if (isChange(baseObj, obj))
                             {
                                 obj.UPDATE_DATE = DateTime.Now;
                             }

                             // 変更を反映
                             en.SaveChanges();
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
            return ss[0].StartsWith("アイテム");
        }
        int setValue(string v1, string v2, string v3)
        {
            return Int32.Parse(v1) + Int32.Parse(v2) * 10 + Int32.Parse(v3) * 100;
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

            return false;
        }
    }
}