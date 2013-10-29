namespace PAWA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using PAWA.Models;
    using PAWA.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<PAWA.DAL.PAWAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PAWA.DAL.PAWAContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var types = new List<PAWA.Models.Type>
            {
                new PAWA.Models.Type { FileType = FileType.Image, Extension = ".png", 
                    FirstDateTime = DateTime.Parse("2013/08/27 14:21:16"), Status = Status.Active },

                new PAWA.Models.Type { FileType = FileType.Video, Extension = ".mp4", 
                    FirstDateTime = null, Status = Status.Inactive }
            };

            types.ForEach(t => context.Types.AddOrUpdate(p => p.Extension, t));
            context.SaveChanges();

            var users = new List<User>
            {
                new User { Username = "CaptalAngine", Password = "12345", Email = "bridgette14792@gmail.com",
                    JoinDateTime = DateTime.Parse("2013/06/28 14:59:11"), Status = Status.Active,
                    DeleteDateTime = null, Country = "Sweden", DateOfBirth = DateTime.Parse("1987/04/15"),
                    Gender = Gender.Female },

                new User { Username = "TVMegaFan", Password = "qwert", Email = "jimmyjamz@hotmail.com",
                    JoinDateTime = DateTime.Parse("2013/06/28 14:59:29"), Status = Status.Active,
                    DeleteDateTime = null, Country = "USA", DateOfBirth = DateTime.Parse("1996/02/29"),
                    Gender = Gender.Male }
            };

            users.ForEach(u => context.Users.AddOrUpdate(p => p.Username, u));
            context.SaveChanges();

            var folders = new List<Folder>
            {
                new Folder { UserID = 1, InFolderID = null, 
                    CreateDateTime = DateTime.Parse("2013/08/28 13:21:50"), 
                    FolderName = "Australian Holiday" },

                new Folder { UserID = 1, InFolderID = 1, 
                    CreateDateTime = DateTime.Parse("2013/08/29 17:16:15"), 
                    FolderName = "Sydney" }
            };

            folders.ForEach(f => context.Folders.AddOrUpdate(p => p.FolderName, f));
            context.SaveChanges();

            var files = new List<File>
            {
                new File { UserID = 1, TypeID = 1, FolderID = 2, Tags = "1,2", 
                    Filename = "839782adf0f886f2a7cedee64ba05a71985279cf805756c072ec0c6cb4c8760f.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:15"), 
                    Description = "A killer koala, seen in its natural habit waiting for its prey.", 
                    SizeMB = 780, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "2d80cf81124d5057a38050c895004da6a95fcfae9f3d86117fb9b782b04e1d4a.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:25"), 
                    Description = "That flower that's hard to say and even harder to spell...but they make great tea.", 
                    SizeMB = 879, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "5f3b380e8ed98f8b2125bc5112681ba5352a449554e66a78506290950d8b2946.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:35"), 
                    Description = "Desert.", 
                    SizeMB = 845, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "8477e434351ebcce936ab0a0cd9211cea9b9f47b44cca5785fe6558b8739508a.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:45"), 
                    Description = "Flower.", 
                    SizeMB = 595, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "9cee7bfd4d41b11a35f9e62bd4cfd84fb55ed82c4c663c6456e2e5b295fd00b4.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:55"), 
                    Description = "The invasion has begun.", 
                    SizeMB = 775, SizeHeight = 768, SizeWidth = 1024 }
            };

            files.ForEach(f => context.Files.AddOrUpdate(p => p.Description, f));
            context.SaveChanges();

            var tags = new List<Tags>
            {
                new Tags { TagName ="Sydney", FirstDateTime = DateTime.Parse("2013/08/27 17:16:15"), 
                    Status = Status.Active, UseCount = 17, UserSuggest = UserSuggest.User },

                new Tags { TagName ="bridge", FirstDateTime = DateTime.Parse("2013/01/04 23:39:09"), 
                    Status = Status.Active, UseCount = 95783, UserSuggest = UserSuggest.Suggested }
            };

            tags.ForEach(t => context.Tags.AddOrUpdate(p => p.TagName, t));
            context.SaveChanges();


            var stats = new List<DailyStatistics>
            {
                new DailyStatistics { Date = DateTime.Parse("2013/08/27"), UsersAddedCount = 5, 
                    UsersLostCount = 0, ImagesAddedCount = 20, ImagesLostCount = 2, 
                    VideosAddedCount = null, VideosLostCount = null }
            };

            stats.ForEach(s => context.DailyStatistics.AddOrUpdate(p => p.Date, s));
        }
    }
}
