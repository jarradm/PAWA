namespace PAWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FolderTableForeignKeyFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Folder", "Folder_FolderID", "dbo.Folder");
            DropIndex("dbo.Folder", new[] { "Folder_FolderID" });
            AddForeignKey("dbo.Folder", "InFolderID", "dbo.Folder", "FolderID");
            CreateIndex("dbo.Folder", "InFolderID");
            DropColumn("dbo.Folder", "Folder_FolderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Folder", "Folder_FolderID", c => c.Int());
            DropIndex("dbo.Folder", new[] { "InFolderID" });
            DropForeignKey("dbo.Folder", "InFolderID", "dbo.Folder");
            CreateIndex("dbo.Folder", "Folder_FolderID");
            AddForeignKey("dbo.Folder", "Folder_FolderID", "dbo.Folder", "FolderID");
        }
    }
}
