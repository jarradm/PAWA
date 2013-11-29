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
        public ActionResult EditFolder(FormCollection form, string saveChanges, string cancelChanges)
        {
            if (saveChanges != null)
            {
                Tools tool = new Tools();

                int index = Convert.ToInt32(form["fid"]);
                var folders = from f in dbContext.Folders where f.FolderID == index select f;
                var folder = folders.First();
                Folder infolder;

                ViewBag.FolderID = new SelectList(dbContext.Folders, "FolderID", "FolderName", folder.InFolderID);
                folder.FolderName = form["FolderName"];
                if (form["InFolderID"] == "") // If putting it in root folder
                {
                    folder.InFolderID = null;
                }
                else // Check that it is not going inside itself
                {
                    bool isFail = true;
                    int inIndex = Convert.ToInt32(form["InFolderID"]);
                    do
                    {
                        var infolders = from f in dbContext.Folders where f.FolderID == inIndex select f;
                        infolder = infolders.First();
                        inIndex = Convert.ToInt32(infolder.InFolderID);
                    }
                    while ((isFail = (infolder.InFolderID != null)) && (infolder.InFolderID != folder.FolderID));
                    if (isFail == false)
                    {
                        folder.InFolderID = Convert.ToInt32(form["InFolderID"]);
                    }
                    else { return Content("This Edit Has Failed"); }
                }
                if (ModelState.IsValid)
                {
                    dbContext.Entry(folder).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    Response.Redirect("./../Home/Album?folderID=" + folder.InFolderID);
                    // return View();
                }
                return View();
            }
            else if (cancelChanges != null)
            {
                return RedirectToAction("./../Home/Album/", new { folderID = form["InFolderID"] }); ;
            }
            else
            {
                return View();
            }
        }
    }
}
