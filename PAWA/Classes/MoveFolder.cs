using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAWA.DAL;
using PAWA.Models;

namespace PAWA.Classes
{
    public class UserIDType
    {
        public string userID { get; set; }
    }

    public class MoveItemList
    {
        public string destinationFolder { get; set; }
        public string selected { get; set; }
        public string sourceFolder { get; set; }
    }

    public class GetFolderFormSelectOptions
    {
        private PAWAContext dbCon = new PAWAContext();
        private Tools toolbelt = new Tools();
        public string returnHTML { get; private set; }
        public int count { get; private set; }
        public GetFolderFormSelectOptions(int userID)
        {
            returnHTML = "";
            IList<Folder> iFolderList = toolbelt.getFolders(1);
            count = iFolderList.Count;
            for (int i = 0; i < count; i++)
            {
                returnHTML += "<option value='" + iFolderList.ElementAt(i).FolderID + 
                    "' id='option" + i + "'>" + iFolderList.ElementAt(i).FolderName + "</option>";

            }

        }
    }
}