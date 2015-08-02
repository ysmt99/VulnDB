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
    class KeyTree<V,T,K> :Dictionary<T,K>,IHasError where K:IHasError
    {
        public V key { set; get; }
        public KeyTree() { }
        public KeyTree (V key) {
            this.key = key;
        }
        public void addError(T key, K value)
        {
            if (value != null)
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
    }
    public interface IHasError {
        bool hasError();
    }

    class ErrorOfAll : KeyTree<int, int, ErrorOfLine>
    {
    }
    class ErrorOfLine : KeyTree<int, CSV列, ErrorOfColumn>
    {
    }
    class ErrorOfColumn: KeyTree<CSV列, 入力規則, ErrorString>
    {
    }
    class ErrorString: IHasError
    {
        public string s { get; set; }
        public bool hasError()
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }
            return true;
        }
    }
}
