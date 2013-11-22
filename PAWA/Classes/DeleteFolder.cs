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
        PAWAContext dbContext = new PAWA.DAL.PAWAContext();

        public void deleteFolder(HttpRequestBase Request, HttpServerUtilityBase Server)
        {

            //dbContext = new PAWA.DAL.PAWAContext();

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
                    deleteFolderChain(delFolder);

                }
                else
                {
                    foldersIndex++;
                }
            }
        }

        public int deleteMultipleFiles(IEnumerable<PAWA.Models.File> CleanMe)
        {
            int returnValue = 0;
            int LengthOfFiles = CleanMe.Count();
            for (int i = 0; i < LengthOfFiles; i++ )
            {
                PAWA.Models.File FileToRemove= CleanMe.ElementAt(0);
                dbContext.Files.Remove(FileToRemove);
                dbContext.SaveChanges();
            }
            returnValue = LengthOfFiles;
            return returnValue;
        }

        public int deleteFolderChain(Folder DeleteMe)
        {
            PAWAContext db = new PAWAContext();
            AlbumGrid toolbelt = new AlbumGrid(dbContext);
            IEnumerable<Folder> listOfInternalFolders = toolbelt.GetFolders(DeleteMe.FolderID);
            IEnumerable<PAWA.Models.File> listOfInternalFiles = toolbelt.GetFiles(DeleteMe.FolderID);

            int nFolderDel = 0;
            int lengthOfInternalFolders;


            if (listOfInternalFolders.Count() > 0)
            {
                lengthOfInternalFolders = listOfInternalFolders.Count();
            }
            else
            {
                lengthOfInternalFolders = 0;
            }

            for (int i = 0; i < lengthOfInternalFolders; i++)
            {
                Folder delFolder = listOfInternalFolders.ElementAt(0);
                nFolderDel += deleteFolderChain(delFolder);
            }

            deleteMultipleFiles(listOfInternalFiles);
            dbContext.Folders.Remove(DeleteMe);
            dbContext.SaveChanges();
            return nFolderDel;
        }


            public IEnumerable<Folder> GetFolders()
            {
                var UserID = 1;
                var folders = from f in dbContext.Folders
                              where f.UserID == UserID
                              select f;
                return folders;
            }

            public PAWA.Models.Folder GetFolder(int FolderID)
            {
                var UserID = 1;
                var folders = from f in dbContext.Folders
                              where f.UserID == UserID &&
                              f.FolderID == FolderID
                              select f;

                return folders.First(); 
            }

            public int GetSubFolders(int FolderID)
            { 
                var UserID = 1;
                
                int returnValue = FolderID;
                PAWAContext db = new PAWAContext();
                Tools toolbelt = new Tools();
                IList<PAWA.Models.Folder> foldermodel = toolbelt.getFolders(UserID);


                for (int i =0; i < foldermodel.Count; i++)
                {
                    if (foldermodel.ElementAt(i).InFolderID == FolderID)
                    {
                        returnValue = foldermodel.ElementAt(i).FolderID;
                    }
                }
                return returnValue;
            }
        }
    }