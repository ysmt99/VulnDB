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
            if (!hasError()) // エラーがなければ空のリスト
            {
                return new List<string>();
            }
            // エラーがあればエラーメッセージをリストにして返す
            return new List<string>() {this.s};
        }
    }
}
