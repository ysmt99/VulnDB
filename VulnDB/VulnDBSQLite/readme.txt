■開発環境構築
以下の3つのツールをインストール
1.sqlitebrowser-3.7.0-win64.exe
sqliteのDB参照更新ツール
2.sqlite-netFx451-setup-bundle-x64-2013-1.0.97.0.exe
sqlite DBアクセスライブラリ
3.sqlite-netFx451-setup-bundle-x86-2013-1.0.97.0.exe
sqlite DBアクセスライブラリ、IDEデザイナ


■VulnDBSQLite
・dbをsqliteにしたアプリ。
・参照しているDBは、VulnDBSQLiteプロジェクト配下のVulnDBSQLite.db
・DBの参照先は、app.configに定義
  connection stringのsourceプロパティを変更
---
    <add name="VulnDBSQLiteEntities" 
    connectionString="metadata=res://*/db.SIDfm.csdl|res://*/db.SIDfm.ssdl|res://*/db.SIDfm.msl;provider=System.Data.SQLite.EF6;provider 
                      connection string=&quot;data source=D:\_z\VulnDB\VulnDB\VulnDBSQLite\VulnDBSQLite.db&quot;" 
                      providerName="System.Data.EntityClient" />
---