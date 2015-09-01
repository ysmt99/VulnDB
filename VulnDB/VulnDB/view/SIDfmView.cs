using SIDfmContext;
using SIDfmContext.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace VulnDB
{
    public class SIDfmView
    {
        SIDfm bean;
        public SIDfmView(SIDfm o)
        {
            bean = o;
            //var t = typeof(SIDfm);
            //var proplist = t.GetProperties();
            //foreach (var prop in proplist)
            //{
            //    prop.SetValue(this, prop.GetValue(parent), null);
            //}
        }
        
        public string SIDfmId
        {
            get { return bean.SIDfmId.ToString(); }
            set { ; }
        }
        public string タイトル
        {
            get { return bean.タイトル; }
            set { ; }
        }
        public string CVE番号
        {
            get { return bean.CVE番号; }
            set { ; }
        }
        public string CVSS基本値
        {
            get
            {
                return (0 != bean.CVSS基本値) ? bean.CVSS基本値.ToString() : "";
            }
            set { ;}
        }
        static Dictionary<int, string> 攻撃元map = new Dictionary<int, string>(){
                {0,""},
                {1,"ローカル"},
                {10,"隣接"},
                {100,"ネットワーク"}};
        public string 攻撃元 
        {
            get { return 攻撃元map[bean.攻撃元.GetValueOrDefault()]; }
            set { ; }
        }
        static Dictionary<int, string> 攻撃成立条件map = new Dictionary<int, string>(){
                {0,""},
                {1,"難しい"},
                {10,"やや難"},
                {100,"簡単"}};
        public string 攻撃成立条件
        {
            get { return 攻撃成立条件map[bean.攻撃成立条件.GetValueOrDefault()]; }
            set { ;}
        }
        static Dictionary<int, string> 攻撃前の認証map = new Dictionary<int, string>(){
                {0,""},
                {1,"複数"},
                {10,"単一"},
                {100,"不要"}};
        public string 攻撃前の認証 {
            get { return 攻撃前の認証map[bean.攻撃前の認証.GetValueOrDefault()]; }
            set { ;}
        }
        static Dictionary<int, string> 情報漏えいmap = new Dictionary<int, string>(){
                {0,""},
                {1,"影響なし"},
                {10,"部分的"},
                {100,"全面的"}};
        public string 情報漏えい {
            get { return 情報漏えいmap[bean.情報漏えい.GetValueOrDefault()]; }
            set { ;}
        }
        static Dictionary<int, string> 情報改ざんmap = new Dictionary<int, string>(){
                {0,""},
                {1,"影響なし"},
                {10,"部分的"},
                {100,"全面的"}};
        public string 情報改ざん {
            get { return 情報改ざんmap[bean.情報改ざん.GetValueOrDefault()]; }
            set { ;}
        }
        static Dictionary<int, string> 業務停止map = new Dictionary<int, string>(){
                {0,""},
                {1,"影響なし"},
                {10,"部分的"},
                {100,"全面的"}};
        public string 業務停止 {
            get { return 業務停止map[bean.業務停止.GetValueOrDefault()]; }
            set { ;}
        }
        public string 攻撃コードの有無
        {
            get
            {
                return (bean.攻撃コードの有無 == 1) ? "あり" : "なし";
            }
            set { ;}
        }
        // CVSS環境値：SIDfmから情報が取得できないので固定値をセットする
        public string 攻撃される可能性
        {
            get
            {
                return String.IsNullOrEmpty(this.CVSS基本値)? "":"実証可能";
            }
            set
            { ;}
        }
        public string 利用可能な対策のレベル
        {
            get
            {
                return String.IsNullOrEmpty(this.CVSS基本値) ? "" : "正式";
            }
            set
            { ;}
        }
        public string 脆弱性情報の信頼性
        {
            get
            {
                return String.IsNullOrEmpty(this.CVSS基本値) ? "" : "確認済";
            }
            set
            { ;}
        }
        public string CVSS現状値
        {
            get {
                //return String.IsNullOrEmpty(this.CVSS基本値) ? "" : "正式";
                decimal d = bean.CVSS基本値.GetValueOrDefault();
                decimal 攻撃される可能性_E_実証可能 = 1;
                decimal 利用可能な対策のレベル_RL_正式 = 0.9M;
                decimal 脆弱性情報の信頼性_RC_確認済 = 1;
//              現状値 = 基本値 ×E×RL×RC （小数点第 2 位四捨五入）　…式(5)
                d = d * 攻撃される可能性_E_実証可能 * 利用可能な対策のレベル_RL_正式 * 脆弱性情報の信頼性_RC_確認済;
                d = Math.Round(d, 1);
                return d == 0 ? "" : d.ToString();
            }
            set { ;}
        }

        public string 対象製品名
        {
            get
            {
                return bean.対象製品名.Replace(Util.MULTIROW_DELIMITER,Util.MULTIROW_VIEW);
            }
            set { ;}
        }
        public string 対象製品パッチ登録日
        {
            get
            {
                return bean.対象製品パッチ登録日.Replace(Util.MULTIROW_DELIMITER, Util.MULTIROW_VIEW);
            }
            set { ;}
        }
        public DateTime 情報登録日
        {
            get
            {
                return bean.情報登録日.GetValueOrDefault();
            }
            set { ;}
        }
        public string INSERT_DATE
        {
            get
            {
                return Util.DateToStr(bean.INSERT_DATE.GetValueOrDefault());
            }
            set { ;}
        }
        public string UPDATE_DATE
        {
            get
            {
                return Util.DateToStr(bean.UPDATE_DATE.GetValueOrDefault());
            }
            set { ;}
        }
    }
}
