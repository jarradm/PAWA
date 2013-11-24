using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using PAWA.Models;

namespace PAWA.DAL
{
    public class TestPAWAContext : IPAWAContext
    {
        public TestPAWAContext()
        {
            this.Users = new TestDbContext<User>();
            this.Folders = new TestDbContext<Folder>();
            this.Types = new TestDbContext<PAWA.Models.Type>();
            this.Tags = new TestDbContext<Tags>();
            this.Files = new TestDbContext<File>();
            this.DailyStatistics = new TestDbContext<DailyStatistics>();
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Folder> Folders { get; set; }
        public IDbSet<PAWA.Models.Type> Types { get; set; }
        public IDbSet<Tags> Tags { get; set; }
        public IDbSet<File> Files { get; set; }
        public IDbSet<DailyStatistics> DailyStatistics { get; set; }

        public int SaveChanges()
        {
            return 0;
        }
    }
}