using SIDfmContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulnDB.form
{
    class SIDfmForm
    {
        public string SIDfmId { get; set; }                  // 必須、数値
        public string タイトル { get; set; }                // 必須
        public string CVE番号 { get; set; }               // 必須
        public string CVSS基本値 { get; set; }             // 数値(小数点未満あり)
        public string 攻撃元_ローカル { get; set; }        // 0か1
        public string 攻撃元_隣接 { get; set; }          // 0か1
        public string 攻撃元_ネットワーク { get; set; }  // 0か1
        public string 攻撃成立条件_難しい { get; set; }  // 0か1
        public string 攻撃成立条件_やや難 { get; set; }  // 0か1
        public string 攻撃成立条件_簡単 { get; set; }   // 0か1
        public string 攻撃前の認証_複数 { get; set; }   // 0か1
        public string 攻撃前の認証_単一 { get; set; }   // 0か1
        public string 攻撃前の認証_不要 { get; set; }   // 0か1
        public string 情報漏えい_影響無し { get; set; }  // 0か1
        public string 情報漏えい_部分的 { get; set; }       // 0か1
        public string 情報漏えい_全面的 { get; set; }   // 0か1
        public string 情報改ざん_影響無し { get; set; }  // 0か1
        public string 情報改ざん_部分的 { get; set; }   // 0か1
        public string 情報改ざん_全面的 { get; set; }   // 0か1
        public string 業務停止_影響無し { get; set; }   // 0か1
        public string 業務停止_部分的 { get; set; }    // 0か1
        public string 業務停止_全面的 { get; set; }    // 0か1
        public string 攻撃コードの有無 { get; set; }    // 0か1
        public string 情報登録日 { get; set; }           // 日付
        public string[] 対象製品パッチ登録日 { get; set; }

        static Dictionary<Const.CSV列, List<Const.入力規則>> checklist;
        static SIDfmForm()
        {
            checklist = new Dictionary<Const.CSV列, List<Const.入力規則>>();
            checklist[Const.CSV列.SIDfmId] = new List<Const.入力規則>() { Const.入力規則.必須, Const.入力規則.整数 };
            checklist[Const.CSV列.タイトル] = new List<Const.入力規則>() { Const.入力規則.必須 };
            checklist[Const.CSV列.CVE番号] = new List<Const.入力規則>() { Const.入力規則.必須 };
            checklist[Const.CSV列.CVSS基本値] = new List<Const.入力規則>() { Const.入力規則.数値_小数点あり };
            checklist[Const.CSV列.攻撃元_ローカル] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.攻撃元_隣接] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.攻撃元_ネットワーク] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.攻撃成立条件_難しい] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.攻撃成立条件_やや難] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.攻撃成立条件_簡単] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.攻撃前の認証_複数] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.攻撃前の認証_単一] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.攻撃前の認証_不要] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.情報漏えい_影響無し] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.情報漏えい_部分的] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.情報漏えい_全面的] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.情報改ざん_影響無し] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.情報改ざん_部分的] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.情報改ざん_全面的] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.業務停止_影響無し] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.業務停止_部分的] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.業務停止_全面的] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.攻撃コードの有無] = new List<Const.入力規則>() { Const.入力規則.スイッチ_0か1 };
            checklist[Const.CSV列.情報登録日] = new List<Const.入力規則>() { Const.入力規則.日付 };
        }

        public SIDfmForm(string[] ss)
        {
            int i = 0;
            SIDfmId = ss[i++];
            タイトル = ss[i++];
            CVE番号 = ss[i++];
            CVSS基本値 = ss[i++];
            攻撃元_ローカル = ss[i++];
            攻撃元_隣接 = ss[i++];
            攻撃元_ネットワーク = ss[i++];
            攻撃成立条件_難しい = ss[i++];
            攻撃成立条件_やや難 = ss[i++];
            攻撃成立条件_簡単 = ss[i++];
            攻撃前の認証_複数 = ss[i++];
            攻撃前の認証_単一 = ss[i++];
            攻撃前の認証_不要 = ss[i++];
            情報漏えい_影響無し = ss[i++];
            情報漏えい_部分的 = ss[i++];
            情報漏えい_全面的 = ss[i++];
            情報改ざん_影響無し = ss[i++];
            情報改ざん_部分的 = ss[i++];
            情報改ざん_全面的 = ss[i++];
            業務停止_影響無し = ss[i++];
            業務停止_部分的 = ss[i++];
            業務停止_全面的 = ss[i++];
            攻撃コードの有無 = ss[i++];
            情報登録日 = ss[i++];
            // 対象製品パッチ登録日はCSVの列数分
            対象製品パッチ登録日 = new string[ss.Length - i];
            int j = i;
            for (; i < ss.Length; i++)
            {
                対象製品パッチ登録日[i - j] = ss[i];
            }
        }
        public ValidateError validateAll()
        {
            Dictionary<Const.CSV列, string> values = new Dictionary<Const.CSV列, string>();
            values[Const.CSV列.SIDfmId] = SIDfmId;
            values[Const.CSV列.タイトル] = タイトル;
            values[Const.CSV列.CVE番号] = CVE番号;
            values[Const.CSV列.CVSS基本値] = CVSS基本値;
            values[Const.CSV列.攻撃元_ローカル] = 攻撃元_ローカル;
            values[Const.CSV列.攻撃元_隣接] = 攻撃元_隣接;
            values[Const.CSV列.攻撃元_ネットワーク] = 攻撃元_ネットワーク;
            values[Const.CSV列.攻撃成立条件_難しい] = 攻撃成立条件_難しい;
            values[Const.CSV列.攻撃成立条件_やや難] = 攻撃成立条件_やや難;
            values[Const.CSV列.攻撃成立条件_簡単] = 攻撃成立条件_簡単;
            values[Const.CSV列.攻撃前の認証_複数] = 攻撃前の認証_複数;
            values[Const.CSV列.攻撃前の認証_単一] = 攻撃前の認証_単一;
            values[Const.CSV列.攻撃前の認証_不要] = 攻撃前の認証_不要;
            values[Const.CSV列.情報漏えい_影響無し] = 情報漏えい_影響無し;
            values[Const.CSV列.情報漏えい_部分的] = 情報漏えい_部分的;
            values[Const.CSV列.情報漏えい_全面的] = 情報漏えい_全面的;
            values[Const.CSV列.情報改ざん_影響無し] = 情報改ざん_影響無し;
            values[Const.CSV列.情報改ざん_部分的] = 情報改ざん_部分的;
            values[Const.CSV列.情報改ざん_全面的] = 情報改ざん_全面的;
            values[Const.CSV列.業務停止_影響無し] = 業務停止_影響無し;
            values[Const.CSV列.業務停止_部分的] = 業務停止_部分的;
            values[Const.CSV列.業務停止_全面的] = 業務停止_全面的;
            values[Const.CSV列.攻撃コードの有無] = 攻撃コードの有無;
            values[Const.CSV列.情報登録日] = 情報登録日;

            //List<Dictionary<Const.CSV列, string>> errlist = new List<Dictionary<Const.CSV列, string>>();

            ValidateError v = new ValidateError();

            foreach (Const.CSV列 clm in Enum.GetValues(typeof(Const.CSV列)))
            {
                //v.AddError(validate(clm, values[clm]));
            }

            return errlist;
        }
        List<Dictionary<Const.CSV列, string>> validate(Const.CSV列 clm, string value)
        {
            List<Dictionary<Const.CSV列, string>> errlist = new List<Dictionary<Const.CSV列, string>>();

            List<Const.入力規則> rules = checklist[clm];

            foreach (Const.入力規則 rule in rules)
            {
                v.AddError(doValidate(clm, value, rule));
            }

            return errlist;
        }
        Dictionary<Const.CSV列, string> doValidate(Const.CSV列 clm, string value, Const.入力規則 rule)
        {
            Dictionary<Const.CSV列, string> errmsg = new Dictionary<Const.CSV列, string>();
            string s = "";
            string name = Enum.GetName(typeof(Const.CSV列), 0);
            switch (rule)
            {
                case Const.入力規則.必須:
                    if (String.IsNullOrEmpty(value))
                    {
                        s = String.Format("{0}が未入力です。", name);
                    }
                    break;
                case Const.入力規則.整数:
                    int i;
                    if (!Int32.TryParse(value, out i))
                    {
                        s = String.Format("{0}が整数ではありません。", name);
                    }
                    break;
                case Const.入力規則.数値_小数点あり:
                    decimal d;
                    if (!Decimal.TryParse(value, out d))
                    {
                        s = String.Format("{0}が数値ではありません。", name);
                    }
                    break;
                case Const.入力規則.日付:
                    DateTime dt;
                    if (!DateTime.TryParse(value, out dt))
                    {
                        s = String.Format("{0}の日付形式が正しくありません。", name);
                    }
                    break;
                case Const.入力規則.スイッチ_0か1:
                    if (!"0".Equals(value) && !"1".Equals(value))
                    {
                        s = String.Format("{0}は0か1を指定してください。", name);
                    }
                    break;
            }
            if (String.IsNullOrEmpty(s))
            {
                errmsg.Add(clm, s);
            }
            return errmsg;
        }
    }
}
