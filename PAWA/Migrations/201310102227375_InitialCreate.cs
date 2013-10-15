namespace PAWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        JoinDateTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        DeleteDateTime = c.DateTime(),
                        Country = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        FolderID = c.Int(),
                        Tags = c.String(maxLength: 1000),
                        Filename = c.String(maxLength: 200),
                        UploadedDateTime = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 1000),
                        SizeMB = c.Int(nullable: false),
                        SizeHeight = c.Int(nullable: false),
                        SizeWidth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.Type", t => t.TypeID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Folder", t => t.FolderID)
                .Index(t => t.TypeID)
                .Index(t => t.UserID)
                .Index(t => t.FolderID);
            
            CreateTable(
                "dbo.Type",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        FileType = c.Int(nullable: false),
                        Extension = c.String(maxLength: 5),
                        FirstDateTime = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.Folder",
                c => new
                    {
                        FolderID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        InFolderID = c.Int(),
                        CreateDateTime = c.DateTime(nullable: false),
                        FolderName = c.String(maxLength: 50),
                        Folder_FolderID = c.Int(),
                    })
                .PrimaryKey(t => t.FolderID)
                .ForeignKey("dbo.Folder", t => t.Folder_FolderID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.Folder_FolderID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagsID = c.Int(nullable: false, identity: true),
                        TagName = c.String(maxLength: 50),
                        FirstDateTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        UseCount = c.Int(nullable: false),
                        UserSuggest = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagsID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Folder", new[] { "UserID" });
            DropIndex("dbo.Folder", new[] { "Folder_FolderID" });
            DropIndex("dbo.File", new[] { "FolderID" });
            DropIndex("dbo.File", new[] { "UserID" });
            DropIndex("dbo.File", new[] { "TypeID" });
            DropForeignKey("dbo.Folder", "UserID", "dbo.User");
            DropForeignKey("dbo.Folder", "Folder_FolderID", "dbo.Folder");
            DropForeignKey("dbo.File", "FolderID", "dbo.Folder");
            DropForeignKey("dbo.File", "UserID", "dbo.User");
            DropForeignKey("dbo.File", "TypeID", "dbo.Type");
            DropTable("dbo.Tags");
            DropTable("dbo.Folder");
            DropTable("dbo.Type");
            DropTable("dbo.File");
            DropTable("dbo.User");
        }
    }
}
