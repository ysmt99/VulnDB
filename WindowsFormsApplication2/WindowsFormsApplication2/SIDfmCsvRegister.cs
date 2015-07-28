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
                             SIDfmId = Int32.Parse(fields[0]);
                             CVE番号 = fields[2];
                             // データ行なら処理を継続
                             // SIDfmId＋CVE番号が一意キーなので、同じデータが登録済の場合は上書きする。
                             // データがあったら更新
                             // データが無ければ新規作成
                             var rowdata = en.SIDfm.Where(x => x.SIDfmId == SIDfmId && x.CVE番号 == CVE番号);

                             if (rowdata.Count() == 0)
                             {
                                 sidfm = new SIDfm();
                                 sidfm.SIDfmId = SIDfmId;
                                 sidfm.CVE番号 = CVE番号;
                                 en.SIDfm.Add(sidfm);
                             }
                             else
                             {
                                 sidfm = rowdata.First();
                             }

                             sidfm.タイトル = fields[1];
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