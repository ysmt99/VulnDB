using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDfmContext.view
{
    class SIDfmView:SIDfm
    {
        /*
        public 攻撃元_区分 攻撃元 { get; set; }
        public 攻撃成立条件_区分 攻撃成立条件 { get; set; }
        public 攻撃前の認証の有無_区分 攻撃前の認証の有無 { get; set; }
        public 情報漏洩_区分 情報漏洩 { get; set; }
        public 情報改竄_区分 情報改竄 { get; set; }
        public 業務妨害_区分 業務妨害 { get; set; }
        public bool 攻撃コード有 { get; set; }
        public DateTime 登録日付 { get; set; }

        public enum 攻撃元_区分 { ローカル = 0x100, 隣接 = 0x010, ネットワーク = 0x001 }
        public enum 攻撃成立条件_区分 { 難しい, やや難, 簡単 }
        public enum 攻撃前の認証の有無_区分 { 複数, 単一, 不要 }
        public enum 情報漏洩_区分 { 影響なし, 部分的, 全面的 }
        public enum 情報改竄_区分 { 影響なし, 部分的, 全面的 }
        public enum 業務妨害_区分 { 影響なし, 部分的, 全面的 }

        public SIDfmView(SIDfm o)
        {
            bean = o;

            int i = Convert.ToInt32("0x" + form.攻撃元_ネットワーク + form.攻撃元_ローカル + form.攻撃元_隣接);
            //Dictionary<string,攻撃元_区分> 攻撃元d = new Dictionary<string,攻撃元_区分>();
            //攻撃元d.Add("100",攻撃元_区分.ローカル);
            //攻撃元d.Add("010",攻撃元_区分.隣接);
            //攻撃元d.Add("001",攻撃元_区分.ネットワーク);

            //攻撃元 = 攻撃元d[s];


            //var xxxx = Array.Find<攻撃元_区分>(Enum.GetValues(typeof(攻撃元_区分)), x => (int)x == i);
            //if (form.攻撃元_ネットワーク == "1") {
            //    攻撃元 = 攻撃元_区分.ネットワーク;
            //} else if (form.攻撃元_ローカル == "1") {
            //    攻撃元 = 攻撃元_区分.ローカル;
            //} else if (form.攻撃元_隣接 == "1") {
            //    攻撃元 = 攻撃元_区分.隣接;
            //}
            //if (form.攻撃成立条件_難しい == "1")
            //{
            //    攻撃成立条件 = 攻撃成立条件_区分.難しい;
            //}
            //else if (form.攻撃成立条件_やや難 == "1")
            //{
            //    攻撃成立条件 = 攻撃成立条件_区分.やや難;
            //}
            //else if (form.攻撃成立条件_簡単 == "1")
            //{
            //    攻撃成立条件 = 攻撃成立条件_区分.簡単;
            //}
        
        }
        */
    }
}
