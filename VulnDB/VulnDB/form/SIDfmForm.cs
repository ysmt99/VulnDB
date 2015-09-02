using SIDfmContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using CSV列 = VulnDB.Const.CSV列;
using 入力規則 = VulnDB.Const.入力規則;

namespace VulnDB
{
    public class SIDfmVulnForm
    {
        public Dictionary<CSV列,string> values{get; set;}

        public SIDfmVulnForm()
        {
        }
        public SIDfmVulnForm(string[] ss)
        {
            values = new Dictionary<CSV列,string>();
            // CSVファイルの値をセット
            foreach (CSV列 c in Enum.GetValues(typeof(CSV列)))
            {
                // CSVの列数は必ずしも揃っていない（アイテム欄がフィルタによって10未満になる）
                if ((int)c >= ss.Length)
                {
                    break;
                }
                values.Add(c, ss[(int)c]);
            }
        }
        public ErrorOfForm validate(int lineNo)
        {
            SIDfmVulnLineValidator v = new SIDfmVulnLineValidator(lineNo,this);
            return v.validate();
        }
    }
}
