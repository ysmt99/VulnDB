using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV列 = VulnDB.Const.CSV列;
using 入力規則 = VulnDB.Const.入力規則;


namespace VulnDB
{
    ///// <summary>
    ///// Validatorのエラーを格納
    ///// 行（データ）⇒項目⇒ルールに対するエラー
    ///// 1インスタンスは1行。その中に複数項目＋複数入力ルールがある
    ///// </summary>
    //class ErrorsByForm : Dictionary<KeyPair, List<string>>
    //{
    //    public void addError(CSV列 column, 入力規則 rule, string errorMessage) {
    //        KeyPair column = new KeyPair(column, rule);
    //        if (!this.ContainsKey(column))
    //        {
    //            this.Add(column, new List<string>() {errorMessage});
    //        }
    //        else
    //        {
    //            this[column].Add(errorMessage);
    //        }
    //    }
    //    public string toString(CSV列 column)
    //    {
            
    //        Enum.GetName(typeof(CSV列), this[Key.csv);
    //    }
    //}
    //class ErrorsByColumn : Dictionary<入力規則, string>{
    //    public static bool hasError(ErrorsByColumn obj)
    //    {
    //        // 値が入っていればtrue＝エラーである。
    //        // 値が入っていなければfalse=エラーではない。
    //        if (obj == null)
    //        {
    //            return false;
    //        }
    //        List<入力規則> rules = obj.Keys.ToList();
    //        foreach (入力規則 rule in rules)
    //        {
    //            if (!String.IsNullOrEmpty(obj[rule]))
    //            {
    //                return true;
    //            }
    //        }
    //        return true;
    //    }
    //};
    //class ErrorsOfLine : Dictionary<CSV列, ErrorsByColumn> {
    //    public void addError(CSV列 column, ErrorsByColumn rule)
    //    {
    //        // キーがない場合、および値のListがnullの場合はリストを作る
    //        if (!ContainsKey(column) || this[column] == null)
    //        {
    //            List<ErrorsByColumn> list = new List<ErrorsByColumn>();
    //            this[column] = list;
    //        }
    //        this[column].Add(rule);
    //    }
    //    public static bool hasError(ErrorsOfLine obj)
    //    {
    //        List<CSV列> columns = obj.Keys.ToList();
    //        List<ErrorsByColumn> rulesObjects;
    //        foreach (CSV列 c in columns)
    //        {
    //            rulesObjects = obj[c];
    //            foreach (ErrorsByColumn ruleObj in rulesObjects)
    //            {
    //                if (ErrorsByColumn.hasError(ruleObj))
    //                {
    //                    return true;
    //                }
    //            }
    //        }
    //        return false;
    //    }
    //};

    //class ErrorsByForm : Dictionary<int, ErrorsOfLine>
    //{
    //    public void addError(int line, ErrorsOfLine obj)
    //    {
    //        // キーがない場合、および値のListがnullの場合はリストを作る
    //        if (!ContainsKey(line) || this[line] == null)
    //        {
    //            List<ErrorsOfLine> list = new List<ErrorsOfLine>();
    //            this[line] = list;
    //        }
    //        this[line].Add(obj);
    //    }
    //    public static bool hasError(ErrorsByForm obj)
    //    {
    //        List<int> lines = obj.Keys.ToList();
    //        List<ErrorsOfLine> columnsObjects;
    //        foreach (int i in lines)
    //        {
    //            columnsObjects = obj[i];
    //            foreach (ErrorsOfLine c in columnsObjects)
    //            {
    //                if (ErrorsOfLine.hasError(c))
    //                {
    //                    return true;
    //                }
    //            }
    //        }
    //        return false;
    //    }
    //}

    // tree構造クラス
    // V⇒クラスのkey
    // T⇒ディクショナリのkey
    // K⇒ディクショナリのvalue
    public class KeyTree<V, T, K> : Dictionary<T, K>, IHasError where K : IHasError
    {
        public V key { set; get; }
        public KeyTree() { }
        public KeyTree (V key) {
            this.key = key;
        }
        public void addError(T key, K value)
        {
            if (value != null && value.hasError())
            {
                this.Add(key,value);
            }
        }
        public bool hasError()
        {
            List<T> keys = this.Keys.ToList();
            foreach (T key in keys)
            {
                if (this[key].hasError())
                {
                    return true;
                }
            }
            return false;
        }
        public List<string> getErrorMessages()
        {
            List<String> list = new List<string>();
            List<T> keys = this.Keys.ToList();
            foreach (T key in keys)
            {
                list.AddRange(this[key].getErrorMessages());
            }
            return list;
        }
    }
    ///// <summary>
    ///// 項目ごとの入力チェック
    ///// </summary>
    ///// <returns></returns>
    //public class Validator<VALIDATECLASS, KEY> where VALIDATECLASS : new()
    //{
    //    public VALIDATECLASS validate(string value) {
    //        VALIDATECLASS error = new VALIDATECLASS();
    //        foreach (KEY key in Enum.GetValues(typeof(KEY)))
    //        {
    //            error.addError(key.validate(key,value));
    //        }
    //        return error;
    //    }
    //}
    // line clm,               clm,               clm,               clm
    //      clm,rule,rule,rule,clm,rule,rule,rule,clm,rule,rule,rule,clm,rule,rule,rule

    public interface IHasError {
        bool hasError();
        List<string> getErrorMessages();
    }

    public class ErrorOfAll : KeyTree<int, int, ErrorOfForm>
    {
    }
    public class ErrorOfForm : KeyTree<int, CSV列, ErrorOfColumn>
    {
    }
    public class ErrorOfColumn : KeyTree<CSV列, 入力規則, ErrorOfRule>
    {
    }
    public class ErrorOfRule : IHasError
    {
        public string s { get; set; }
        public ErrorOfRule() { }
        public ErrorOfRule(string s)
        {
            this.s = s;
        }
        public bool hasError()
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }
            return true;
        }
        public List<string> getErrorMessages()
        {
            return new List<string>() {this.s};
        }
    }
}
