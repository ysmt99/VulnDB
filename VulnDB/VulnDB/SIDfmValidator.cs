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

        public CSV列 column;
        public List<入力規則> rules;

        public ValidateParams() { }
        public ValidateParams(CSV列 column, List<入力規則> rules)
        {
            this.column = column;
            this.rules = rules;
        }

        public static List<ValidateParams> param;
        static ValidateParams() {
            param = new List<ValidateParams>();
            
            param.Add(new ValidateParams(CSV列.SIDfmId,new List<入力規則>() { 入力規則.必須, 入力規則.整数 }));
            param.Add(new ValidateParams(CSV列.タイトル,new List<入力規則>() { 入力規則.必須 }));
            param.Add(new ValidateParams(CSV列.CVE番号,new List<入力規則>() { 入力規則.必須 }));
            param.Add(new ValidateParams(CSV列.CVSS基本値,new List<入力規則>() { 入力規則.数値_小数点あり }));
            param.Add(new ValidateParams(CSV列.攻撃元_ローカル,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.攻撃元_隣接,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.攻撃元_ネットワーク,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.攻撃成立条件_難しい,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.攻撃成立条件_やや難,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.攻撃成立条件_簡単,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.攻撃前の認証_複数,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.攻撃前の認証_単一,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.攻撃前の認証_不要,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.情報漏えい_影響無し,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.情報漏えい_部分的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.情報漏えい_全面的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.情報改ざん_影響無し,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.情報改ざん_部分的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.情報改ざん_全面的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.業務停止_影響無し,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.業務停止_部分的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.業務停止_全面的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.攻撃コードの有無,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            param.Add(new ValidateParams(CSV列.情報登録日,new List<入力規則>() { 入力規則.日付 }));
            param.Add(new ValidateParams(CSV列.アイテム1, new List<入力規則>() { 入力規則.日付 }));
            param.Add(new ValidateParams(CSV列.アイテム2, new List<入力規則>() { 入力規則.日付 }));
            param.Add(new ValidateParams(CSV列.アイテム3, new List<入力規則>() { 入力規則.日付 }));
            param.Add(new ValidateParams(CSV列.アイテム4, new List<入力規則>() { 入力規則.日付 }));
            param.Add(new ValidateParams(CSV列.アイテム5, new List<入力規則>() { 入力規則.日付 }));
            param.Add(new ValidateParams(CSV列.アイテム6, new List<入力規則>() { 入力規則.日付 }));
            param.Add(new ValidateParams(CSV列.アイテム7, new List<入力規則>() { 入力規則.日付 }));
            param.Add(new ValidateParams(CSV列.アイテム8, new List<入力規則>() { 入力規則.日付 }));
            param.Add(new ValidateParams(CSV列.アイテム9, new List<入力規則>() { 入力規則.日付 }));
            param.Add(new ValidateParams(CSV列.アイテム10, new List<入力規則>() { 入力規則.日付 }));
        }
    }
    //class SIDfmValidator
    //{
    //    //public CSV列 column;
    //    //public List<入力規則> rules;

    //    //public SIDfmValidator() {}
    //    //public SIDfmValidator(CSV列 column, List<入力規則> rules)
    //    //{
    //    //    this.column = column;
    //    //    this.rules = rules;
    //    //}

    //    //public ErrorOfForm validateLine(int lineNo)
    //    //{
    //    //    ErrorOfForm errorOfLine = new ErrorOfForm();
    //    //    ErrorOfColumn errorOfColumn;
    //    //    SIDfmValidator validator;
    //    //    foreach (CSV列 c in Enum.GetValues(typeof(CSV列)))
    //    //    {
    //    //        validator = getValidator(c);
    //    //        if (validator != null)
    //    //        {
    //    //            errorOfColumn = validator.validateByColumn(values[c]);
    //    //            errorOfLine.addError(validator.column, errorOfColumn);
    //    //        }
    //    //    }
    //    //    return errorOfLine;
    //    //}

    //    ///// <summary>
    //    ///// 項目ごとの入力チェック
    //    ///// </summary>
    //    ///// <returns></returns>
    //    //public ErrorOfColumn validateByColumn(string value)
    //    //{
    //    //    ErrorOfColumn error = new ErrorOfColumn();
    //    //    foreach (入力規則 rule in rules)
    //    //    {
    //    //        error.addError(rule,validateByRule(column,rule,value));
    //    //    }
    //    //    return error;
    //    //}
    //    ///// <summary>
    //    /// ルールごとの入力チェック
    //    /// </summary>
    //    /// <returns></returns>
    //    public string validateByRule(CSV列 key, 入力規則 rule, string value)
    //    {
    //        string errorMessage = "";
    //        string name = Enum.GetName(typeof(CSV列), key);

    //        // 必須の場合は無条件に値を見る
    //        // 必須以外の場合、値が入っていたら書式チェックを行う
    //        switch (rule)
    //        {
    //            case 入力規則.必須:
    //                if (String.IsNullOrEmpty(value))
    //                {
    //                    errorMessage = String.Format("{0}が未入力です。", name);
    //                }
    //                break;
    //            case 入力規則.整数:
    //                int i;
    //                if (!String.IsNullOrEmpty(value) && !Int32.TryParse(value, out i))
    //                {
    //                    errorMessage = String.Format("{0}が整数ではありません。", name);
    //                }
    //                break;
    //            case 入力規則.数値_小数点あり:
    //                decimal d;
    //                if (!String.IsNullOrEmpty(value) && !Decimal.TryParse(value, out d))
    //                {
    //                    errorMessage = String.Format("{0}が数値ではありません。", name);
    //                }
    //                break;
    //            case 入力規則.日付:
    //                DateTime dt;
    //                if (!String.IsNullOrEmpty(value) && !DateTime.TryParse(value, out dt))
    //                {
    //                    errorMessage = String.Format("{0}の日付形式が正しくありません。", name);
    //                }
    //                break;
    //            case 入力規則.スイッチ_0か1:
    //                if (!String.IsNullOrEmpty(value) && !"0".Equals(value) && !"1".Equals(value))
    //                {
    //                    errorMessage = String.Format("{0}は0か1を指定してください。", name);
    //                }
    //                break;
    //        }
    //        return errorMessage;
    //    }
    //}
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
            ErrorOfColumn errorOfColumn;
            SIDfmColumnValidator validator;
            foreach (CSV列 c in Enum.GetValues(typeof(CSV列)))
            {
                validator = new SIDfmColumnValidator(c, form);
                if (validator != null)
                {
                    errorOfColumn = validator.validate();
                    errorOfForm.addError(validator.column, errorOfColumn);
                }
            }
            return errorOfForm;
        }
    }
    public class SIDfmColumnValidator
    {
        public CSV列 column { set; get; }
        public SIDfmForm form { set; get; }
        public SIDfmColumnValidator() { }
        public SIDfmColumnValidator(CSV列 c, SIDfmForm f) {
            column = c;
            form = f;
        }
        public ErrorOfColumn validate()
        {
            ErrorOfColumn errorOfColumn = new ErrorOfColumn();
            ErrorOfRule errorOfRule;
            SIDfmRuleValidator validator;
            foreach (入力規則 r in Enum.GetValues(typeof(入力規則)))
            {
                validator = getValidator(r);
                if (validator != null)
                {
                    errorOfRule = validator.validateByRule(values[r]);
                    errorOfColumn.addError(validator.rule, errorOfRule);
                }
            }
            return errorOfColumn;
        }
    }
    public class SIDfmRuleValidator
    {
        public 入力規則 rule { set; get; }
        public SIDfmForm form { set; get; }
        public SIDfmRuleValidator() { }
        public SIDfmRuleValidator(入力規則 r, SIDfmForm f)
        {
            rule = r;
            form = f;
        }
        public ErrorOfRule validate()
        {
            ErrorOfRule errorOfRule = new ErrorOfRule();
            string errorMessage = "";
            string name = Enum.GetName(typeof(CSV列), key);

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
            return errorMessage;
        }
    }
}
