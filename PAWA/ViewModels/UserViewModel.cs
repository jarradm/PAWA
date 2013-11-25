using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAWA.ViewModels
{
    public class UserViewModel
    {
        public enum Gender1
        {
            Male, Female
        }

        public int UserID { get; set; }

        [StringLength(50, ErrorMessage = "Must be up to 50 characters")]
        [Compare("ConfirmPassword", ErrorMessage = "Passwords must match.")]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Must be between 8 and 100 characters")]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; set; }

        [Required()]
        public string Country { get; set; }

        [Required()]
        public PAWA.Models.Gender Gender { get; set; }
    }
}