using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAWA.Models
{
    public enum FileType
    {
        Image, Video
    }

    public class Type
    {
        public int TypeID { get; set; }
        public FileType FileType { get; set; }

        [StringLength(5)]
        [Required()]
        public string Extension { get; set; }
        public DateTime? FirstDateTime { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<File> File { get; set; }
    }
}