using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using PAWA.Models;
using PAWA.DAL;
using System.Drawing;
using System.Data;

namespace PAWA.Classes
{
    public class DeleteFolder
    {
        PAWAContext dbContext;

        public void deleteFolder(HttpRequestBase Request, HttpServerUtilityBase Server)
        {

            dbContext = new PAWA.DAL.PAWAContext();

            IEnumerable<Folder> folders = GetFolders();

            int foldersIndex = 0;
            string selectedValue;
            while (foldersIndex < folders.Count())
            {
                selectedValue = Request.Form[folders.ElementAt(foldersIndex).FolderID.ToString() + "_folder"];
                int folderID = folders.ElementAt(foldersIndex).FolderID;
                if (selectedValue != null && selectedValue.Equals("on"))
                {
                    Folder delFolder = folders.ElementAt(foldersIndex);

                    dbContext.Folders.Remove(delFolder);
                    dbContext.SaveChanges();
                }
                else
                {
                    foldersIndex++;
                }
            }
        }

    public IEnumerable<Folder> GetFolders()
    {
        var UserID = 1;
        var folders = from f in dbContext.Folders
                      where f.UserID == UserID
                      select f;
        return folders;
    }

            public PAWA.Models.Folder GetFolder(String FolderID)
            {
                var UserID = 1;
                var folders = from f in dbContext.Folders
                              where f.UserID == UserID &&
                              f.FolderName == FolderID
                              select f;

                return folders.First();
            }
        }
    }