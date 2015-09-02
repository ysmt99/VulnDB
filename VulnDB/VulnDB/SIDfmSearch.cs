using SIDfmContext;
using SIDfmContext.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VulnDB
{
    class SIDfmVulnSearch
    {
        internal static DataTable search()
        {
            using (cmdbEntities en = new cmdbEntities())
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

                var beans = en.SIDfmVuln.OrderBy(x => x.CVE番号).OrderBy(x => x.SIDfmVulnId).OrderByDescending(x => x.情報登録日);


                var tbl = new DataTable();
                var t = typeof(SIDfmVulnView);
                var proplist = t.GetProperties();
                foreach (var prop in proplist)
                {
                    tbl.Columns.Add(new DataColumn(prop.Name, prop.PropertyType));
                }

                foreach (var o in beans)
                {
                    var row = tbl.NewRow();
                    SIDfmVulnView view = new SIDfmVulnView(o);
                    foreach (var prop in proplist)
                        row[prop.Name] = prop.GetValue(view);

                    tbl.Rows.Add(row);
                }

                return tbl;
            }
        }
    }

    class SIDfmResourceSearch
    {
        internal static List<string> search()
        {
            using (cmdbEntities en = new cmdbEntities())
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

                var resources = from x in en.SIDfmSoftware 
                                select x.対象製品短縮名;
                return resources.ToList();
            }
        }
    }
}
