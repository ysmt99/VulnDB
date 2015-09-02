using log4net;
using SIDfmContext.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulnDB;

namespace SIDfmContext
{
    class LogWriter
    {
        readonly log4net.ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ActionLog log;
        public LogWriter(Const.アクション種類 actionType)
        {
            log = new ActionLog();
            log.アクション = (long)actionType;
            log.処理開始日時 = DateTime.Now;
        }
        public void writeLog() {
            using (cmdbEntities en = new cmdbEntities())
            {
                log.処理終了日時 = DateTime.Now;
                en.ActionLog.Add(log);
                en.SaveChanges();
            }
        }
    }
}
