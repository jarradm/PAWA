using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAWA.Models
{
    public class Folder
    {
        public int FolderID { get; set; }
        public int UserID { get; set; }
        
        [ForeignKey("Folders")]
        public int? InFolderID { get; set; }
        public DateTime CreateDateTime { get; set; }

        [StringLength(50)]
        [Required()]
        public string FolderName { get; set; }

        
        public virtual ICollection<Folder> Folders { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<File> File { get; set; }
    }
}