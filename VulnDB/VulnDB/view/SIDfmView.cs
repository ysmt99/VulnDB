using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDfmContext.view
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
        public new string 攻撃元
        { 
            get
            {
                Dictionary<int, string> d = new Dictionary<int, string>();
                d[1] = "ローカル";
                d[10] = "隣接";
                d[100] = "ネットワーク";
                return d[(int)base.攻撃元];
            }
        }
        public new string 攻撃成立条件
        {
            get
            {
                Dictionary<int, string> d = new Dictionary<int, string>();
                d[1] = "難しい";
                d[10] = "やや難";
                d[100] = "簡単";
                return d[(int)base.攻撃成立条件];
            }
        }
        public new string 攻撃前の認証
        {
            get
            {
                Dictionary<int, string> d = new Dictionary<int, string>();
                d[1] = "複数";
                d[10] = "単一";
                d[100] = "不要";
                return d[(int)base.攻撃前の認証];
            }
        }
        public new string 情報漏えい
        {
            get
            {
                Dictionary<int, string> d = new Dictionary<int, string>();
                d[1] = "影響なし";
                d[10] = "部分的";
                d[100] = "全面的";
                return d[(int)base.情報漏えい];
            }
        }
        public new string 情報改ざん
        {
            get
            {
                Dictionary<int, string> d = new Dictionary<int, string>();
                d[1] = "影響なし";
                d[10] = "部分的";
                d[100] = "全面的";
                return d[(int)base.情報改ざん];
            }
        }
        public new string 業務停止
        {
            get
            {
                Dictionary<int, string> d = new Dictionary<int, string>();
                d[1] = "影響なし";
                d[10] = "部分的";
                d[100] = "全面的";
                return d[(int)base.業務停止];
            }
        }
        public new string 攻撃コードの有無
        {
            get
            {
                if (base.攻撃コードの有無 == 1)
                {
                    return "あり";
                }
                else
                {
                    return "なし";
                }
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
