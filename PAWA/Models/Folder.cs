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
}