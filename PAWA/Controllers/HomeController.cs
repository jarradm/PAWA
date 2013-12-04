using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.Models;
using PAWA.DAL;
using PAWA.Classes;
using System.Drawing;
using System.Data;
using PAWA.ViewModels;
using WebMatrix.WebData;

namespace PAWA.Controllers
{
    [Authorize(Roles="User")]
    public class HomeController : Controller
    {
        private PAWAContext dbContext;

        public HomeController()
        {
            dbContext = new PAWAContext();
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return RedirectToAction("Album");
        }

        //
        // GET: /Home/AlbumTree

        public ActionResult Album(int? folderID = null)
        {
            var InFolderId = (from f in dbContext.Folders
                             where f.FolderID == folderID
                             select f.InFolderID).SingleOrDefault();

            AlbumGrid ag = new AlbumGrid(dbContext);
            AlbumViewModel avm = new AlbumViewModel
            {
                AlbumGridTable = (ag.CreateTable(folderID)),
                FolderID = folderID,
                InFolderID = InFolderId
            };

            return View(avm);
        }
        /*
        [HttpPost]
        public ActionResult CreateFolder(string folderName, int parentFolder)
        {
            Tools funcs = new Tools();
            Tools.UserID = 1;

            Folder newFolder = new Folder();
            newFolder.UserID = 1;
            newFolder.FolderName = folderName;
            newFolder.InFolderID = parentFolder;
            newFolder.CreateDateTime = DateTime.Now;

            UpdateModel(newFolder);
            
            
            return PartialView();
        }*/

        
        [HttpPost]
        public ActionResult GetAlbumList() {
            /*
             * int UserID=WebSecurity.CurrentUserId;
            
            try
            {
                UserID = Convert.ToInt32(value.userID);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("eror: " + e);
                UserID = 0;//Response.Output;
            }
            */
            /*
            string returnValue = "";
            returnValue += "{";
            for (int i = 0; i < folderList.Count(); )
            {
                returnValue += i+":{FolderID:\""+i+"\",";
                returnValue += "FolderName:\"" + i + "\"},";
            }
            returnValue += "length:" + folderList.Count() + "}";

            var folderList = from f in dbContext.Folders
                             where f.UserID == UserID
                             select f.Folders;
            ViewBag.userID = UserID;
            */
            return PartialView();
        }

        private IList<string> splitToIList(string stringToSplit, string splitAt)
        {
            IList<string> returnValue = new List<string>();
            string[] splitString = stringToSplit.Split((new string[]{splitAt}),StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splitString.Length; i++)
            {
                returnValue.Add(splitString[i]);
            }
            return returnValue;
        }
        
        [HttpPost]
        public ActionResult MoveFolderTo(MoveItemList moveItemList)
        {

            Tools toolbelt = new Tools();
            int? newFolderID;
            int? currentFolder;
            IList<string> selectedItems = new List<string> { };
            {// Initialise Posted string variables into workable data
                if (moveItemList.selected != null)
                {
                    selectedItems = moveItemList.selected.Split((new char[] { ',' }), StringSplitOptions.RemoveEmptyEntries);
                }
                newFolderID = Convert.ToInt32(moveItemList.destinationFolder);
                currentFolder = Convert.ToInt32(moveItemList.sourceFolder);
                if (currentFolder <= 0) { currentFolder = null; }
            }

            string ReturnValue = "Count :" + selectedItems.Count  ;
            // Move all the folders that need be moved.
            for (int i = 0; i < selectedItems.Count ; i++)
            {
                bool SuccessfulMove = toolbelt.moveFolder(WebSecurity.CurrentUserId, selectedItems.ElementAt(i).ToString(), newFolderID);
                ReturnValue += "Folder : " + selectedItems.ElementAt(i).ToString() + " : Success : " + SuccessfulMove + "\n"; 
            }

            return Content(ReturnValue);
        }

        [HttpPost]
        public ActionResult MoveImageTo(MoveItemList moveItemList)
        {
            IList<string> selectedItems = new List<string> { };
            if (moveItemList.selected != null)
            {
                selectedItems = moveItemList.selected.Split((new char[] { ',' }), StringSplitOptions.RemoveEmptyEntries);
            }
            int? newFolderID = Convert.ToInt32(moveItemList.destinationFolder);
            int? currentFolder = Convert.ToInt32(moveItemList.sourceFolder);
            if (currentFolder <= 0) { currentFolder = null; }
            IList<Folder> listOfUserFolders;
            IEnumerable<File> listOfUserFiles;
            {
                Tools toolbelt = new Tools();
                listOfUserFolders = toolbelt.getFolders(WebSecurity.CurrentUserId);
            }
            {
                AlbumGrid toolbelt = new AlbumGrid(dbContext);
                listOfUserFiles = toolbelt.GetFiles(currentFolder);
            }

            int amountOfUserFolders = listOfUserFolders.Count;
            IList<File> filesToMove = new List<File>();

            string ReturnValue = "";
            ReturnValue += "Selected Items Count : " + selectedItems.Count + " : " + selectedItems.Count();
            ReturnValue += "\nFolders Count : " + listOfUserFolders.Count + " : " + listOfUserFolders.Count();
            ReturnValue += "\nFiles Count  : " + listOfUserFiles.Count() ;
            if (listOfUserFiles.Count() > 0){ReturnValue += "\nFileID : " + listOfUserFiles.ElementAt(listOfUserFiles.Count()-1).Description;}
            ReturnValue += "\nNew Folder ID : " + newFolderID.ToString();

            for (int i = 0; i < amountOfUserFolders; i++){
                // Go through every folder
            
                if (listOfUserFolders.ElementAt(i).FolderID == newFolderID){
                    // FolderID(i) == FolderID.FromAJAX
                    // MAKE SURE the folder exists
                
                    int numberOfFilesInFolder = listOfUserFiles.Count();
                    for (int n = 0; n < numberOfFilesInFolder; n++)
                    {
                        for (int j = 0; j < selectedItems.Count; j++)
                        {
                            int fileIdFromAJAX = -1;

                            /* Catch Bogus Array values*/
                            try { fileIdFromAJAX = Convert.ToInt32(selectedItems.ElementAt(j)); }
                            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e); }

                            if (listOfUserFiles.ElementAt(n).FileID == fileIdFromAJAX)
                            {
                                filesToMove.Add(listOfUserFiles.ElementAt(n));
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < filesToMove.Count; i++)
            {
                MoveFile(filesToMove.ElementAt(i), newFolderID);
                ReturnValue += "\nFilesToMove : " + filesToMove.ElementAt(i).Description;
            }
            return Content(ReturnValue);
        }

        private void MoveFile(File fileToEdit,int? newFolderID)
        {
            if (newFolderID < 0) { newFolderID = null; }
            fileToEdit.FolderID = newFolderID;
            dbContext.Entry<File>(fileToEdit).State = EntityState.Modified;
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine("Error : " + e); }
        }


        
        [HttpPost]
        public ActionResult Album(string DropDownList, string Submit, AlbumViewModel avm)
        {
            //If the go button was pushed and the dropdown was delete
            if (Submit != null && DropDownList.Equals("Delete"))
            {
                //Call Delete Method
                DeleteImage deleteImage = new DeleteImage();
                deleteImage.deleteMultipleImages(Request, Server);
                DeleteFolder deleteFolder = new DeleteFolder();
                deleteFolder.deleteFolder(Request, Server);
            }
            if (Submit != null && DropDownList.Equals("Move")) 
            { 

            }
            // Recreate the grid tables
            AlbumGrid ag = new AlbumGrid(dbContext);
            avm.AlbumGridTable = ag.CreateTable(avm.FolderID);

                /*
            AlbumViewModel avm = new AlbumViewModel
            {
                AlbumGridTable = (ag.CreateTable(folderID)),
                InFolderID = f.getParentID(folderID).ToString()
            };
                 * */

            //Re-load the view
            return View(avm);
        }
    }
}
