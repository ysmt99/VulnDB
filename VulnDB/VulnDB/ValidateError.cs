using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDfmContext
{
    /// <summary>
    /// Validatorのエラーを格納
    /// 行（データ）⇒項目⇒ルールに対するエラー
    /// </summary>
    class ValidateError
    {
        int lineno { get; set; }
        List<>
        class keyPair {
            Const.CSV列 key1 {get;set;}
            Const.入力規則 key2{get;set;}
            string toString() {

            }  
        }
        class twoKeyValue
        {
            List<string> errors;
        }


        //// 1行(インスタンス)の中には複数の項目がある
        ////List<Prop> props { get; set; }
        ////Dictionary<Const.CSV列, Prop> prop;

        //Dictionary<Const.CSV列, Dictionary<Const.入力規則, List<string>>> errors;


        ////class Prop
        ////{
        ////    //Dictionary<Const.入力規則, List<Rule>> prop;
        ////    Const.CSV列 prop;
        ////    // 1項目には複数の入力規則がある
        ////    List<Rule> rules;
        ////}
        ////class Rule
        ////{
        ////    //Dictionary<Const.入力規則, List<string>> errorMsg;
        ////    Const.入力規則 rule;
        ////    // 1入力規則に対して複数のエラーが発生する
        ////    List<string> errors;
        ////}

        //public void addError(Const.CSV列 prop, Const.入力規則 rule, string errorMsg)
        //{
        //    if (!errors.ContainsKey(prop))
        //    {

        //    }

        //    if (!errors[prop][rule].Contains(errorMsg)){
        //        errors[prop][rule].Add(errorMsg);
        //    }
        //}
    }
}
