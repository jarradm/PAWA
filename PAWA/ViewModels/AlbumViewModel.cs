using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAWA.DAL;
using PAWA.Classes;
using PAWA.Models;

namespace PAWA.ViewModels
{
    public class AlbumViewModel
    {
        public AlbumGrid ag;
        public int? FolderID { get; set; }

        public AlbumViewModel(IPAWAContext dbContext)
        {
            ag = new AlbumGrid(dbContext);
        }
    }
}