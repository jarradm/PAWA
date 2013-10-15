using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using PAWA.Models;

namespace PAWA.DAL
{
    public class PAWAContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<PAWA.Models.Type> Types { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<DailyStatistics> DailyStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}