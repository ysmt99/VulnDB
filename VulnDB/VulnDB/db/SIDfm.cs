//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIDfmContext.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class SIDfm
    {
        public long SIDfmId { get; set; }
        public string タイトル { get; set; }
        public string CVE番号 { get; set; }
        public Nullable<decimal> CVSS基本値 { get; set; }
        public Nullable<int> 攻撃元 { get; set; }
        public Nullable<int> 攻撃成立条件 { get; set; }
        public Nullable<int> 攻撃前の認証 { get; set; }
        public Nullable<int> 情報漏えい { get; set; }
        public Nullable<int> 情報改ざん { get; set; }
        public Nullable<int> 業務停止 { get; set; }
        public Nullable<int> 攻撃コードの有無 { get; set; }
        public Nullable<System.DateTime> 情報登録日 { get; set; }
        public string 対象製品名 { get; set; }
        public string 対象製品パッチ登録日 { get; set; }
        public Nullable<System.DateTime> INSERT_DATE { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
    }
}
