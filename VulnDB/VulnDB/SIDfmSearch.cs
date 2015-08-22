using log4net;
using SIDfmContext;
using SIDfmContext.db;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VulnDB
{
    class SIDfmSearch
    {
        static readonly log4net.ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        internal static List<SIDfmView> search()
        {
            try
            {
                using (SIDfmSQLiteEntities en = new SIDfmSQLiteEntities())
                {
                    var connectionString = en.Database.Connection.ConnectionString;
                    var matchCollection = Regex.Matches(connectionString, "source=(?<value>.*)", RegexOptions.IgnoreCase);
                    if (matchCollection.Count > 0)
                    {
                        foreach (Match match in matchCollection)
                        {
                            var fileName = match.Groups["value"].Value;
                            if (!File.Exists(fileName))
                                throw new ArgumentException("DBファイルが存在しません：" + fileName);
                            break;
                        }
                    }
//                    List<SIDfm> beans =
//                     (from x in en.SIDfm
//                      orderby x.情報登録日 descending, x.SIDfmId, x.CVE番号
//                      select x);

                    var beans = en.SIDfm.OrderBy(x => x.CVE番号).OrderBy(x => x.SIDfmId).OrderByDescending(x => x.情報登録日);
                    List<SIDfmView> views = new List<SIDfmView>();
                    foreach (var o in beans)
                    {
                        views.Add(new SIDfmView(o));
                    }

                    return views;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.ToString());
                throw;
            }
           // return  new List<SIDfmView>();
        }
    }
}
