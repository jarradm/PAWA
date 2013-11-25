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
            //EditFolder ef = new EditFolder();
            PAWA.Models.Folder folder = dbContext.Folders.Find(folderid);
            if (folder == null)
            {
                return HttpNotFound(folder.ToString());
            }
            ViewBag.FolderID = new SelectList(dbContext.Folders, "FolderID", "FolderName", folder.FolderID);
            return View(folder);
        }

        // POST: /Folder/Edit/5

        [HttpPost]
        public ActionResult EditFolder(FormCollection formal)
        {
            //EditFolder ef = new EditFolder();
            Tools tool = new Tools();
            int index = Convert.ToInt32(formal["FolderID"]);
            var folders = from f in dbContext.Folders where f.FolderID == index select f;
            var folder = folders.First();
            folder.FolderName = formal["FolderName"];
            folder.FolderID = Convert.ToInt32(formal["FolderID"]);
            
            if (ModelState.IsValid)
            {
                dbContext.Entry(folder).State = EntityState.Modified;
                dbContext.SaveChanges();
                return View("/Home/Album");
            }
            ViewBag.UserID = new SelectList(dbContext.Users, "UserID", "UserName", folder.UserID);
            ViewBag.FolderID = new SelectList(dbContext.Folders, "FolderID", "FolderName", folder.FolderID);
            return View();
        }
    }
}
