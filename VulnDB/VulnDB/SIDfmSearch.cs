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
    class SIDfmSearch
    {
        internal static DataTable search()
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

                var beans = en.SIDfm.OrderBy(x => x.CVE番号).OrderBy(x => x.SIDfmId).OrderByDescending(x => x.情報登録日);


                var tbl = new DataTable();
                var t = typeof(SIDfmView);
                var proplist = t.GetProperties();
                foreach (var prop in proplist)
                {
                    tbl.Columns.Add(new DataColumn(prop.Name, prop.PropertyType));
                }

                foreach (var o in beans)
                {
                    var row = tbl.NewRow();
                    SIDfmView view = new SIDfmView(o);
                    foreach (var prop in proplist)
                        row[prop.Name] = prop.GetValue(view);

                    tbl.Rows.Add(row);
                }

                return tbl;
            }
        }
    }
}
