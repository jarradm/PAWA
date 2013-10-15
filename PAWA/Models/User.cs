using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAWA.Models
{
    public enum Gender
    {
        Male, Female
    }

    public class User
    {
        public int UserID { get; set; }
        
        [StringLength(50)]
        [Required()]
        public string Username { get; set; }

        [StringLength(50)]
        [Required()]
        public string Password { get; set; }

        [StringLength(100)]
        [Required()]
        public string Email { get; set; }
        public DateTime JoinDateTime { get; set; }
        public Status Status { get; set; }
        public DateTime? DeleteDateTime { get; set; }

        [Required()]
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public virtual ICollection<File> File { get; set; }
        public virtual ICollection<Folder> Folder { get; set; }
    }
}