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
        
        public List<string> AlbumGridTable { get; set; }

        public AlbumViewModel(List<string> table)
        {
            AlbumGridTable = table;
        }
    }
}