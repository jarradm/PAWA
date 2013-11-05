using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using PAWA.Models;

namespace PAWA.DAL
{
    public interface IPAWAContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Folder> Folders { get; set; }
        IDbSet<PAWA.Models.Type> Types { get; set; }
        IDbSet<Tags> Tags { get; set; }
        IDbSet<File> Files { get; set; }
        IDbSet<DailyStatistics> DailyStatistics { get; set; }

        int SaveChanges();
    }
}