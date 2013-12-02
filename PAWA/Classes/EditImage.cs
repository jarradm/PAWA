using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.DAL;
using PAWA.Models;
using System.Drawing;
using PAWA.Classes;
using System.IO;
using System.Data;


namespace PAWA.Controllers
{
    public class EditImage
    {
        public int GetID(string filename)
        {
            int value = 0;
            PAWAContext dbContext = new PAWAContext();
            var identifier = from f in dbContext.Files
                             where f.Filename == filename
                             select f.FileID;
            value = identifier.SingleOrDefault();
            return value;
        }

        public string GetFilename(int ID)
        {
            string value = "";
            PAWAContext dbContext = new PAWAContext();
            var identifier = from f in dbContext.Files
                             where f.FileID == ID
                             select f.Filename;
            value = identifier.SingleOrDefault();
            return value;
        }

        public string[] seperateTags(string s)
        {
            string[] TagArr;
            string temp = s;
            int i = 0;

            TagArr = temp.Split(',');
            foreach (string tag in TagArr)
            {
                TagArr[i] = tag.Trim();
                i++;
            }
            return TagArr;
        }

        public string stringOfTags(FormCollection form)
        {
            Tools tool = new Tools();
            string[] Taglist = seperateTags(form["StringTag"]);
            List<int> TagIDs = tool.checkIfTagExists(Taglist);
            string Tagfinal = tool.convertTagsToString(TagIDs);

            return Tagfinal;
        }

        public int? InFolderSetting(string FolderID)
        {
                if (FolderID == "")
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(FolderID);
                }
        }
    }
}
