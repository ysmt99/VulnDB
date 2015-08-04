using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV列 = VulnDB.Const.CSV列;
using 入力規則 = VulnDB.Const.入力規則;

namespace VulnDB
{
    class ValidateParams {

        public static Dictionary<CSV列, List<入力規則>> param;
        static ValidateParams() {
            param = new Dictionary<CSV列, List<入力規則>>();
            param.Add(CSV列.SIDfmId, new List<入力規則>() { 入力規則.必須, 入力規則.整数 });
            param.Add(CSV列.タイトル, new List<入力規則>() { 入力規則.必須 });
            param.Add(CSV列.CVE番号, new List<入力規則>() { 入力規則.必須 });
            param.Add(CSV列.CVSS基本値, new List<入力規則>() { 入力規則.数値_小数点あり });
            param.Add(CSV列.攻撃元_ローカル, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.攻撃元_隣接, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.攻撃元_ネットワーク, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.攻撃成立条件_難しい, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.攻撃成立条件_やや難, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.攻撃成立条件_簡単, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.攻撃前の認証_複数, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.攻撃前の認証_単一, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.攻撃前の認証_不要, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.情報漏えい_影響無し, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.情報漏えい_部分的, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.情報漏えい_全面的, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.情報改ざん_影響無し, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.情報改ざん_部分的, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.情報改ざん_全面的, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.業務停止_影響無し, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.業務停止_部分的, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.業務停止_全面的, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.攻撃コードの有無, new List<入力規則>() { 入力規則.スイッチ_0か1 });
            param.Add(CSV列.情報登録日, new List<入力規則>() { 入力規則.日付 });
            param.Add(CSV列.アイテム1, new List<入力規則>() { 入力規則.日付 });
            param.Add(CSV列.アイテム2, new List<入力規則>() { 入力規則.日付 });
            param.Add(CSV列.アイテム3, new List<入力規則>() { 入力規則.日付 });
            param.Add(CSV列.アイテム4, new List<入力規則>() { 入力規則.日付 });
            param.Add(CSV列.アイテム5, new List<入力規則>() { 入力規則.日付 });
            param.Add(CSV列.アイテム6, new List<入力規則>() { 入力規則.日付 });
            param.Add(CSV列.アイテム7, new List<入力規則>() { 入力規則.日付 });
            param.Add(CSV列.アイテム8, new List<入力規則>() { 入力規則.日付 });
            param.Add(CSV列.アイテム9, new List<入力規則>() { 入力規則.日付 });
            param.Add(CSV列.アイテム10, new List<入力規則>() { 入力規則.日付 });
        }
    }
    public class SIDfmLineValidator
    {
        public int lineNo { set; get; }
        public SIDfmForm form { set; get; }
        public SIDfmLineValidator() { }
        public SIDfmLineValidator(int i, SIDfmForm f)
        {
            lineNo = i;
            form = f;
        }
        public ErrorOfForm validate()
        {
            ErrorOfForm errorOfForm = new ErrorOfForm();
            foreach (CSV列 c in ValidateParams.param.Keys.ToList())
            {
                errorOfForm.addError(c, new SIDfmColumnValidator(c, form.values[c]).validate());
            }
            return errorOfForm;
        }
    }
    public class SIDfmColumnValidator
    {
        public CSV列 column { set; get; }
        public string value { set; get; }
        public SIDfmColumnValidator() { }
        public SIDfmColumnValidator(CSV列 c, string s) {
            column = c;
            value = s;
        }
        public ErrorOfColumn validate()
        {
            ErrorOfColumn errorOfColumn = new ErrorOfColumn();
            List<入力規則> rules = ValidateParams.param[column];
            foreach (入力規則 r in rules)
            {
                errorOfColumn.addError(r, new SIDfmRuleValidator(column,r, this.value).validate());
            }
            return errorOfColumn;
        }
    }
    public class SIDfmRuleValidator
    {
        public CSV列 column { set; get; }
        public 入力規則 rule { set; get; }
        public string value { set; get; }
        public SIDfmRuleValidator() { }
        public SIDfmRuleValidator(CSV列 c,入力規則 r, string s)
        {
            column = c;
            rule = r;
            value = s;
        }
        public ErrorOfRule validate()
        {
            ErrorOfRule errorOfRule = new ErrorOfRule();
            string errorMessage = "";
            string name = Enum.GetName(typeof(CSV列), column);

            // 必須の場合は無条件に値を見る
            // 必須以外の場合、値が入っていたら書式チェックを行う
            switch (rule)
            {
                case 入力規則.必須:
                    if (String.IsNullOrEmpty(value))
                    {
                        errorMessage = String.Format("{0}が未入力です。", name);
                    }
                    break;
                case 入力規則.整数:
                    int i;
                    if (!String.IsNullOrEmpty(value) && !Int32.TryParse(value, out i))
                    {
                        errorMessage = String.Format("{0}が整数ではありません。", name);
                    }
                    break;
                case 入力規則.数値_小数点あり:
                    decimal d;
                    if (!String.IsNullOrEmpty(value) && !Decimal.TryParse(value, out d))
                    {
                        errorMessage = String.Format("{0}が数値ではありません。", name);
                    }
                    break;
                case 入力規則.日付:
                    DateTime dt;
                    if (!String.IsNullOrEmpty(value) && !DateTime.TryParse(value, out dt))
                    {
                        errorMessage = String.Format("{0}の日付形式が正しくありません。", name);
                    }
                    break;
                case 入力規則.スイッチ_0か1:
                    if (!String.IsNullOrEmpty(value) && !"0".Equals(value) && !"1".Equals(value))
                    {
                        errorMessage = String.Format("{0}は0か1を指定してください。", name);
                    }
                    break;
            }
            return new ErrorOfRule(errorMessage);
        }
    }
}
