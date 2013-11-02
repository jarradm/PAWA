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
                    Filename = "39237a426ae7e39182ea4c286cb3c250bde66ccba0b9b9944e5a7818a1a0a49e.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:15"), 
                    Description = "A killer koala, seen in its natural habit waiting for its prey.", 
                    SizeMB = 780, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "3ab28c4f18e4daee52ffa4587016ba491c45812d7d1051e24b191648b3d152e7.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:25"), 
                    Description = "That flower that's hard to say and even harder to spell...but they make great tea.", 
                    SizeMB = 879, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "1b3a3eb3fda1e33ae12a954a3e433557de17ea2bb04990a332b1015e7df638c8.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:35"), 
                    Description = "Desert.", 
                    SizeMB = 845, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "38ab90242284a5106e273e406efe84f533f652ca5fa51d30f11af581f2c032ad.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:45"), 
                    Description = "Flower.", 
                    SizeMB = 595, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "82579f271ca76ddae60732c761804e0a090e8dd6fd85e9d43dfab981cb881567.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:55"), 
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
