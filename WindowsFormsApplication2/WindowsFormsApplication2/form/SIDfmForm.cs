using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulnDB.form
{
    class SIDfmForm
    {
        // 
        public string ID { get; set; }
        public string タイトル { get; set; }
        public string CVE番号 { get; set; }
        public string CVSS基本値 { get; set; }
        public string 攻撃元_ローカル { get; set; }
        public string 攻撃元_隣接 { get; set; }
        public string 攻撃元_ネットワーク { get; set; }
        public string 攻撃成立条件_難しい { get; set; }
        public string 攻撃成立条件_やや難 { get; set; }
        public string 攻撃成立条件_簡単 { get; set; }
        public string 攻撃前の認証の有無_複数 { get; set; }
        public string 攻撃前の認証の有無_単一 { get; set; }
        public string 攻撃前の認証の有無_不要 { get; set; }
        public string 情報漏洩_影響無し { get; set; }
        public string 情報漏洩_部分的 { get; set; }
        public string 情報漏洩_全面的 { get; set; }
        public string 情報改竄_影響無し { get; set; }
        public string 情報改竄_部分的 { get; set; }
        public string 情報改竄_全面的 { get; set; }
        public string 業務妨害_影響無し { get; set; }
        public string 業務妨害_部分的 { get; set; }
        public string 業務妨害_全面的 { get; set; }
        public string 攻撃コード有 { get; set; }
        public string 登録日付 { get; set; }
        public Dictionary<string, string> パッチ登録日 { get; set; }

        public SIDfmForm(string[] ss)
        {
            int i = 0;
            ID = ss[i++];
            タイトル = ss[i++];
            CVE番号 = ss[i++];
            CVSS基本値 = ss[i++];
            攻撃元_ローカル = ss[i++];
            攻撃元_隣接 = ss[i++];
            攻撃元_ネットワーク = ss[i++];
            攻撃成立条件_難しい = ss[i++];
            攻撃成立条件_やや難 = ss[i++];
            攻撃成立条件_簡単 = ss[i++];
            攻撃前の認証の有無_複数 = ss[i++];
            攻撃前の認証の有無_単一 = ss[i++];
            攻撃前の認証の有無_不要 = ss[i++];
            情報漏洩_影響無し = ss[i++];
            情報漏洩_部分的 = ss[i++];
            情報漏洩_全面的 = ss[i++];
            情報改竄_影響無し = ss[i++];
            情報改竄_部分的 = ss[i++];
            情報改竄_全面的 = ss[i++];
            業務妨害_影響無し = ss[i++];
            業務妨害_部分的 = ss[i++];
            業務妨害_全面的 = ss[i++];
            攻撃コード有 = ss[i++];
            登録日付 = ss[i++];
        }
    }
}
