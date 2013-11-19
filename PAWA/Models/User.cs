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

        [StringLength(50, ErrorMessage = "Must be up to 50 characters")]
        [Required(ErrorMessage = "Password required.")]
        public string Password { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Must be between 8 and 100 characters")]
        [Required(ErrorMessage = "Email required.")]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; set; }

        public DateTime JoinDateTime { get; set; }
        public Status Status { get; set; }
        public DateTime? DeleteDateTime { get; set; }

        [Required(ErrorMessage = "Country required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Date of Birth required.")]
        public DateTime DateOfBirth { get; set; }

        [Required()]
        public Gender Gender { get; set; }

        public virtual ICollection<File> File { get; set; }
        public virtual ICollection<Folder> Folder { get; set; }
    }
}