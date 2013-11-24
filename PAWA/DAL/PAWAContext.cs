using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using PAWA.Models;

namespace PAWA.DAL
{
    public class PAWAContext : DbContext, IPAWAContext
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<Folder> Folders { get; set; }
        public IDbSet<PAWA.Models.Type> Types { get; set; }
        public IDbSet<Tags> Tags { get; set; }
        public IDbSet<File> Files { get; set; }
        public IDbSet<DailyStatistics> DailyStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}