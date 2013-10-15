namespace PAWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableNullableUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.User", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Type", "Extension", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Folder", "FolderName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tags", "TagName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "TagName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Folder", "FolderName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Type", "Extension", c => c.String(maxLength: 5));
            AlterColumn("dbo.User", "Country", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.User", "Password", c => c.String(maxLength: 50));
            AlterColumn("dbo.User", "Username", c => c.String(maxLength: 50));
        }
    }
}
