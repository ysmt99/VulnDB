using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using アクション種類 = VulnDB.Const.アクション種類;

namespace SIDfmContext
{
    public class ActionLogger
    {
        public string Id { get; set; }
        public アクション種類 アクション  { get; set; }
        public DateTime 処理開始日時 { get; set; }
        public DateTime 処理終了日時 { get; set; }

//        public bool 処理結果 { get; set; }
//        public List<アクションログ_詳細> 詳細リスト { get; set; }
    }
    //public enum 管理項目 { 
    //    件数_新規, 件数_更新, 件数_削除, 商品件数
    //}
    //public class アクションログ_詳細
    //{
    //    public 管理項目 項目 { get; set; }
    //    public string 値 { get; set; }
    //}
}
