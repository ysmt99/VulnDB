using SIDfmContext.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulnDB;

namespace SIDfmContext
{
    class LogSearch
    {
        public DateTime getLastTimeOfCSVUpload()
        {
            using (cmdbEntities en = new cmdbEntities())
            {
                return en.ActionLog.Where(x => x.アクション == (long)Const.アクション種類.CSV登録).Max(x => x.処理終了日時);
            }
        }
    }
}
