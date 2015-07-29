using log4net;
using SIDfmContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulnDB
{
    class SIDfmSearch
    {
        static readonly log4net.ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        internal static List<SIDfm> search()
        {
            try
            {
                using (SIDfmEntities en = new SIDfmEntities())
                {
                    //return (from x in en.SIDfm
                    //       orderby x.情報登録日 descending, x.SIDfmId, x.CVE番号
                    //       select x).ToList();
                    return en.SIDfm.OrderBy(x=>x.CVE番号).OrderBy(x=>x.SIDfmId).OrderByDescending(x=>x.情報登録日).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.ToString());
                throw;
            }
        }
    }
}
