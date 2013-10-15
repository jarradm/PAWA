using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAWA.Models
{
    public class File
    {
        public int FileID { get; set; }
        public int UserID { get; set; }
        public int TypeID { get; set; }
        public int? FolderID { get; set; }

        [StringLength(1000)]
        public string Tags { get; set; }

        [StringLength(200)]
        public string Filename { get; set; }
        public DateTime UploadedDateTime { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        public int SizeMB { get; set; }
        public int SizeHeight { get; set; }
        public int SizeWidth { get; set; }

        public virtual Type Type { get; set; }
        public virtual User User { get; set; }
        public virtual Folder Folder { get; set; }
    }
}