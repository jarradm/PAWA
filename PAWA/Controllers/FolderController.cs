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
using System.Data.Entity;
using WebMatrix.WebData;

namespace PAWA.Controllers
{
    public class FolderController : Controller
    {
        //
        // GET: /Folder/

        PAWAContext dbContext = new PAWAContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditFolder(int folderid)
        {
            PAWA.Models.Folder folder = dbContext.Folders.Find(folderid);
            if (folder == null)
            {
                return HttpNotFound(folder.ToString());
            }
            ViewBag.InFolderID = new SelectList(dbContext.Folders.Where(f => f.FolderID != folderid), "FolderID", "FolderName", folder.InFolderID);
            ViewBag.fid = folderid;

            return View(folder);
        }

        // POST: /Folder/Edit/5

        [HttpPost]
        public ActionResult EditFolder(FormCollection formal)
        {
            Tools tool = new Tools();
            tool.moveFolder(WebSecurity.CurrentUserId, formal["fid"], formal["InFolderID"]);
            Folder folder = tool.getFolder(WebSecurity.CurrentUserId, formal["fid"]);
            folder.FolderName = formal["FolderName"];
            if (ModelState.IsValid)
            {
                dbContext.Entry(folder).State = EntityState.Modified;
                dbContext.SaveChanges();
                Response.Redirect("./../Home/Album?folderID=" + folder.InFolderID);
                // return View();
            }
            /*
            /// Will become the Get Folder method in the data retrieval tools
            int index = Convert.ToInt32(formal["fid"]);
            var folders = from f in dbContext.Folders where f.FolderID == index select f;
            var folder = folders.First();

            /// Will become the Move folder Method in the data manipulation tools
            Folder infolder;

            if (formal["InFolderID"] == "") // If putting it in root folder
            {
                folder.InFolderID = null;
            }
            else // Check that it is not going inside itself
            {
                bool isFail = true;
                int inIndex = Convert.ToInt32(formal["InFolderID"]);
                do
                {
                    var infolders = from f in dbContext.Folders where f.FolderID == inIndex select f;
                    infolder = infolders.First();
                    inIndex = Convert.ToInt32(infolder.InFolderID);
                }
                while ((isFail = (infolder.InFolderID != null)) && (infolder.InFolderID != folder.FolderID));
                if (isFail == false)
                {
                    folder.InFolderID = Convert.ToInt32(formal["InFolderID"]);
                }
                else { return Content("This Edit Has Failed"); } // return (!isFail);
                // Method will return the true false 
            }   
            if (ModelState.IsValid)
            {
                dbContext.Entry(folder).State = EntityState.Modified;
                dbContext.SaveChanges();
                Response.Redirect("./../Home/Album?folderID=" + folder.InFolderID);
                // return View();
            }
             */
            ViewBag.UserID = new SelectList(dbContext.Users, "UserID", "UserName", folder.UserID);
            ViewBag.FolderID = new SelectList(dbContext.Folders, "FolderID", "FolderName", folder.InFolderID);
            return View();
        }
    }
}
