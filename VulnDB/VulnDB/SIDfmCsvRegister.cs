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
            情報登録日
        };

        internal void doRegist(string s)
        {
            try
            {
                using (
                TextFieldParser file = new TextFieldParser(s, Encoding.GetEncoding(932))
                {
                    //フィールドが文字で区切られているとする
                    //デフォルトでDelimitedなので、必要なし
                    //区切り文字を,とする
                    //フィールドを"で囲み、改行文字、区切り文字を含めることができるか
                    //デフォルトでtrueなので、必要なし
                    //フィールドの前後からスペースを削除する
                    //デフォルトでtrueなので、必要なし
                    TextFieldType = FieldType.Delimited,
                    Delimiters = new string[] { "," },
                    HasFieldsEnclosedInQuotes = true,
                    TrimWhiteSpace = true
                }
                )
                using ( SIDfmEntities en = new SIDfmEntities())
                {
                    SIDfm sidfm;
                    //1行読んで列分割
                    string[] fields;
                    int SIDfmId;
                    string CVE番号;
                
                     // csvファイルを全行読み込み
                     while (!file.EndOfData)
                     {
                         fields = file.ReadFields();

                         // ヘッダー部分には説明文は対象のソフトウェア名などが入っている。
                         // 先頭列が数値の行を「データ行」として扱う。
                         if (isDataLine(fields))
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
                                 sidfm = new SIDfm();
                                 // SIDfmIdとCVE番号はキー項目なので新規の場合のみセットする
                                 sidfm.SIDfmId = SIDfmId;
                                 sidfm.CVE番号 = CVE番号;
                                 sidfm.INSERT_DATE = DateTime.Now;
                                 en.SIDfm.Add(sidfm);
                             }
                             else
                             {
                                 sidfm = rowdata.First();
                             }

                             // 新規、更新共通の更新
                             sidfm.タイトル = fields[(int)CSV列.タイトル];
                             sidfm.CVSS基本値 = Convert.ToDecimal(fields[(int)CSV列.CVSS基本値]);

                             // この3区分は通常いずれか1つだけが「1」で、それ以外は「0」が入っている。
                             // 何かの間違いで複数列に「1」が入っている場合のために、
                             // 危険度が高い値を後ろに置いて、上書きされるようにしている。
                             if (fields[(int)CSV列.攻撃元_ローカル] == "1") {
                                 sidfm.攻撃元 = 0.4m;
                             } 
                             if (fields[(int)CSV列.攻撃元_隣接] == "1") {
                                 sidfm.攻撃元 = 0.6m;
                             } 
                             if (fields[(int)CSV列.攻撃元_ネットワーク] == "1") {
                                 sidfm.攻撃元 = 1.0m;
                             }
                             // 攻撃成立条件
                             if (fields[(int)CSV列.攻撃成立条件_難しい] == "1")
                             {
                                 sidfm.攻撃成立条件 = 0.4m;
                             }
                             if (fields[(int)CSV列.攻撃成立条件_やや難] == "1")
                             {
                                 sidfm.攻撃成立条件 = 0.6m;
                             }
                             if (fields[(int)CSV列.攻撃成立条件_簡単] == "1")
                             {
                                 sidfm.攻撃成立条件 = 0.7m;
                             }
                             // 攻撃前の認証
                             if (fields[(int)CSV列.攻撃前の認証_複数] == "1")
                             {
                                 sidfm.攻撃前の認証 = 0.5m;
                             }
                             if (fields[(int)CSV列.攻撃前の認証_単一] == "1")
                             {
                                 sidfm.攻撃前の認証 = 0.6m;
                             }
                             if (fields[(int)CSV列.攻撃前の認証_不要] == "1")
                             {
                                 sidfm.攻撃前の認証 = 0.7m;
                             }
                             // 情報漏えい
                             if (fields[(int)CSV列.情報漏えい_影響無し] == "1")
                             {
                                 sidfm.情報漏えい = 0.0m;
                             }
                             if (fields[(int)CSV列.情報漏えい_部分的] == "1")
                             {
                                 sidfm.情報漏えい = 0.3m;
                             }
                             if (fields[(int)CSV列.情報漏えい_全面的] == "1")
                             {
                                 sidfm.情報漏えい = 0.7m;
                             }
                             // 情報改ざん
                             if (fields[(int)CSV列.情報改ざん_影響無し] == "1")
                             {
                                 sidfm.情報改ざん = 0.0m;
                             }
                             if (fields[(int)CSV列.情報改ざん_部分的] == "1")
                             {
                                 sidfm.情報改ざん = 0.3m;
                             }
                             if (fields[(int)CSV列.情報改ざん_全面的] == "1")
                             {
                                 sidfm.情報改ざん = 0.7m;
                             }
                             // 業務停止
                             if (fields[(int)CSV列.業務停止_影響無し] == "1")
                             {
                                 sidfm.業務停止 = 0.0m;
                             }
                             if (fields[(int)CSV列.業務停止_部分的] == "1")
                             {
                                 sidfm.業務停止 = 0.3m;
                             }
                             if (fields[(int)CSV列.業務停止_全面的] == "1")
                             {
                                 sidfm.業務停止 = 0.7m;
                             }
                             
                             sidfm.攻撃コードの有無 = Int32.Parse(fields[(int)CSV列.攻撃コードの有無]);
                             sidfm.情報登録日 = DateTime.Parse(fields[(int)CSV列.情報登録日]);
                             sidfm.UPDATE_DATE = DateTime.Now;

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

        // データ行は先頭列が数値の場合は正常なものと識別ｓる
        bool isDataLine(string[] ss)
        {
            int dummy;
            return Int32.TryParse(ss[0], out dummy);
        }
        bool isNotDataLine(string[] ss)
        {
            return isDataLine(ss) ? false : true;
        }
    }
}