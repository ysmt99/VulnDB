using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV列 = VulnDB.Const.CSV列;
using 入力規則 = VulnDB.Const.入力規則;

namespace VulnDB
{
    class SIDfmFormValidator
    {
        public CSV列 column;
        public List<入力規則> rules;

        public SIDfmFormValidator() {}
        public SIDfmFormValidator(CSV列 column, List<入力規則> rules)
        {
            this.column = column;
            this.rules = rules;
        }
        /// <summary>
        /// 項目ごとの入力チェック
        /// </summary>
        /// <returns></returns>
        public ErrorOfColumn validateByColumn(string value)
        {
            ErrorOfColumn error = new ErrorOfColumn();
            foreach (入力規則 rule in rules)
            {
                error.addError(rule,validateByRule(column,rule,value));
            }
            return error;
        }
        /// <summary>
        /// ルールごとの入力チェック
        /// </summary>
        /// <returns></returns>
        public string validateByRule(CSV列 key, 入力規則 rule, string value)
        {
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
