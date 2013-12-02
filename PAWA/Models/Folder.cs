using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PAWA.DAL;
using System.Drawing;
using System.Security.Cryptography;

namespace PAWA.Models
{
    public class Folder
    {
        public int FolderID { get; set; }
        public int UserID { get; set; }
        
        [ForeignKey("Folders")]
        public int? InFolderID { get; set; }
        public DateTime CreateDateTime { get; set; }

        [StringLength(50, MinimumLength=3, ErrorMessage="Name must be between 3 and 50 characters in length")]
        [Required(ErrorMessage="Folder must have a name")]
        public string FolderName { get; set; }

        
        public virtual ICollection<Folder> Folders { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<File> File { get; set; }
    }
    /*
            public static T Insert<T>(T o) where T : Entity
        {
            o.Id = Gid += 2;
            ((IList<T>)Set<T>()).Add(o);
            return o;
        }

    static CreateSomeFolders()
    {
        Insert(new Folder { FolderName = "New Year", InFolderID = null });
        Insert(new Folder { FolderName = "Birthday", InFolderID = null }); 
        Insert(new Folder { FolderName = "Jill and Jan", InFolderID = 1 }); 
        Insert(new Folder { FolderName = "Flowers", InFolderID = 1 }); 

    }
    */

}