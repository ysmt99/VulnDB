using SIDfmContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    static class Util
    {
        //public static SIDfm deepCopy(SIDfm src)
        //{
        //    SIDfm dest = new SIDfm();
        //    var proplist = typeof(SIDfm).GetProperties();
        //    foreach (var prop in proplist)
        //    {
        //        prop.SetValue(dest, prop.GetValue(src), null);
        //    }
        //    return dest;
        //}
        public static T deepCopy<T>(T src) where T: new()
        {
            T dest = new T();
            var proplist = typeof(T).GetProperties();
            foreach (var prop in proplist)
            {
                prop.SetValue(dest, prop.GetValue(src), null);
            }
            return dest;
        }

        public static string MULTIROW_DELIMITER = "@@";
        public static string MULTIROW_VIEW = "／";
        /// <summary>
        /// 1カラムに複数列データが入っている（区切り文字で区切り）ものを分割する
        /// </summary>
        /// <param name="src">1カラムの状態になっているデータ</param>
        /// <returns>分割後の配列</returns>
        public static string[] spritMultiRowInSingleColumn(string src)
        {
            if (String.IsNullOrEmpty(src))
            {
                return null;
            }
            string[] ss = src.Split(new string[] { MULTIROW_DELIMITER }, StringSplitOptions.RemoveEmptyEntries);
            return ss;
        }
        /// <summary>
        /// 1カラムに複数テキストが入っている場合の処理
        /// ・カラムには複数テキストが「@@」区切りで入っている
        /// ・テキストの追加時に、既存のテキストと同じものがあったら追加しない
        /// </summary>
        /// <param name="basetext"></param>
        /// <param name="addtext"></param>
        /// <returns></returns>
        public static string setMultiRow2SingleColumn(string basetext, string addtext)
        {
            //   元データ   追加データ　処理
            // 1.なし       なし       何もしない
            // 2.なし       あり＊     追加データを登録
            // 3.あり＊     なし       元データを登録（何もしない）
            // 4.あり＊     あり＊     元データに追加データを追加

            // 1
            if (String.IsNullOrEmpty(basetext) && String.IsNullOrEmpty(addtext))
            {
                return "";
            }
            // 2
            if (String.IsNullOrEmpty(basetext) && !String.IsNullOrEmpty(addtext))
            {
                return addtext;
            }
            // 3
            if (!String.IsNullOrEmpty(basetext) && String.IsNullOrEmpty(addtext))
            {
                return basetext;
            }
            // 4
            string[] ss = spritMultiRowInSingleColumn(basetext);
            // 今回追加しようとしているテキストがすでに存在している場合は何もしない
            if (ss.Contains(addtext))
            {
                return basetext;
            }
            // 存在していない場合は追加
            else
            {
                return basetext + MULTIROW_DELIMITER + addtext;
            }
        }
        public static List<string> simpleDeepCopy(List<string> ss)
        {
            List<string> o = new List<string>();
            foreach (string s in ss)
            {
                o.Add(s);
            }
            return o;
        }

        /// <summary>
        /// ディープコピーを作成する。
        /// クローンするクラスには SerializableAttribute 属性、
        /// 不要なフィールドは NonSerializedAttribute 属性をつける。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static T CloneDeep<T>(this T target)
        {
            object clone = null;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, target);
                stream.Position = 0;
                clone = formatter.Deserialize(stream);
            }
            return (T)clone;
        }
        public static string DateToStr(DateTime d)
        {
            return (d != null ? d.ToString("yyyy/mm/dd") : "");
        }
    }
}
