using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAWA.DAL;
using PAWA.Models;

namespace PAWA.Classes
{
    public class DisplayImage
    {
        public static string GetTags(IPAWAContext dbContext, string tagInput)
        {
            string[] tags;
            string tagOutput = null;
            int tagId;

            tags = tagInput.Split(',');

            foreach (var item in tags)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    int.TryParse(item, out tagId);

                    var tagName = from t in dbContext.Tags
                                  where t.TagsID == tagId
                                  select t.TagName;

                    if (tagName.Count() == 1)
                    {
                        if (tagOutput == null)
                        {
                            tagOutput = tagName.SingleOrDefault().ToString();
                        }
                        else
                        {
                            tagOutput += ", " + tagName.SingleOrDefault().ToString();
                        }
                    }
                    //*/
                    //tagOutput = 
                }
            }



            return tagOutput;
        }
    }
}