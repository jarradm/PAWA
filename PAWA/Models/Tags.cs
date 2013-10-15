using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAWA.Models
{
    public enum Status
    {
        Active, Inactive
    }

    public enum UserSuggest
    {
        User, Suggested
    }

    public class Tags
    {
        public int TagsID { get; set; }

        [StringLength(50)]
        [Required()]
        public string TagName { get; set; }
        public DateTime FirstDateTime { get; set; }
        public Status Status { get; set; }
        public int UseCount { get; set; }
        public UserSuggest UserSuggest { get; set; }
    }
}