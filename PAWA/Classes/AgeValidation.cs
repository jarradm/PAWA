using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAWA.Classes
{
    public class AgeValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime parse = (DateTime)value;
            DateTime now;

            now = DateTime.Now;

            // less than 13
            if (now.Year - 13 < parse.Year)
            {
                return false;
            }
            // born 13 years ago to the year
            else if (now.Year - 13 == parse.Year)
            {
                if (now.Month > parse.Month)
                {
                    return false;
                }
                else if (now.Month == parse.Month)
                {
                    if (now.Day > parse.Day)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}