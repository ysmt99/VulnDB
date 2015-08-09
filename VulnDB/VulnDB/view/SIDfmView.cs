using SIDfmContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace VulnDB
{
    class SIDfmView
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
        public string 情報登録日
        {
            get
            {
                return Util.DateToStr(bean.情報登録日.GetValueOrDefault());
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
