using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV列 = VulnDB.Const.CSV列;
using 入力規則 = VulnDB.Const.入力規則;

namespace VulnDB
{
    class KeyPair
    { 
        CSV列 key1 { get; set; }
        入力規則 key2 { get; set; }
        public KeyPair(CSV列 key1, 入力規則 key2)
        {
            this.key1 = key1;
            this.key2 = key2;
        }
    }
}
