using SIDfmContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace VulnDB
{
    class SIDfmView:SIDfm
    {
        public SIDfmView(SIDfm parent)
        {
            var t = typeof(SIDfm);
            var proplist = t.GetProperties();
            foreach (var prop in proplist)
            {
                prop.SetValue(this, prop.GetValue(parent), null);
            }
        }

        static Dictionary<int, string> 攻撃元map = new Dictionary<int, string>(){
                {0,""},
                {1,"ローカル"},
                {10,"隣接"},
                {100,"ネットワーク"}};
        public new string 攻撃元 { get { return 攻撃元map[(int)base.攻撃元]; } }

        static Dictionary<int, string> 攻撃成立条件map = new Dictionary<int, string>(){
                {0,""},
                {1,"難しい"},
                {10,"やや難"},
                {100,"簡単"}};
        public new string 攻撃成立条件 { get { return 攻撃成立条件map[(int)base.攻撃成立条件]; } }

        static Dictionary<int, string> 攻撃前の認証map = new Dictionary<int, string>(){
                {0,""},
                {1,"複数"},
                {10,"単一"},
                {100,"不要"}};
        public new string 攻撃前の認証 { get { return 攻撃前の認証map[(int)base.攻撃前の認証]; } }

        static Dictionary<int, string> 情報漏えいmap = new Dictionary<int, string>(){
                {0,""},
                {1,"影響なし"},
                {10,"部分的"},
                {100,"全面的"}};
        public new string 情報漏えい { get { return 情報漏えいmap[(int)base.情報漏えい]; } }

        static Dictionary<int, string> 情報改ざんmap = new Dictionary<int, string>(){
                {0,""},
                {1,"影響なし"},
                {10,"部分的"},
                {100,"全面的"}};
        public new string 情報改ざん { get { return 情報改ざんmap[(int)base.情報改ざん]; } }

        static Dictionary<int, string> 業務停止map = new Dictionary<int, string>(){
                {0,""},
                {1,"影響なし"},
                {10,"部分的"},
                {100,"全面的"}};
        public new string 業務停止 { get { return 業務停止map[(int)base.業務停止]; } }

        public new string 攻撃コードの有無
        {
            get
            {
                return (base.攻撃コードの有無 == 1) ? "あり" : "なし";
            }
        }
        public new string 対象製品名
        {
            get
            {
                return base.対象製品名.Replace(Util.MULTIROW_DELIMITER,Util.MULTIROW_VIEW);
            }
        }
        public new string 対象製品パッチ登録日
        {
            get
            {
                return base.対象製品パッチ登録日.Replace(Util.MULTIROW_DELIMITER, Util.MULTIROW_VIEW);
            }
        }
    }
}
