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

namespace PAWA.Controllers
{
    [Authorize(Roles="User")]
    public class HomeController : Controller
    {
        private IPAWAContext dbContext;

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
            FoldersController f = new FoldersController();
            f.getParentID(folderID);

            AlbumGrid ag = new AlbumGrid(dbContext);
            AlbumViewModel avm = new AlbumViewModel(ag.CreateTable(folderID));

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
        public ActionResult Album(string DropDownList, string Submit)
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

            // Recreate the grid tables
            AlbumGrid ag = new AlbumGrid(dbContext);
            AlbumViewModel avm = new AlbumViewModel(ag.CreateTable());

            //Re-load the view
            return View(avm);
        }
    }
}
