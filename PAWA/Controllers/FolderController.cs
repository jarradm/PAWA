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

            return PartialView(folder);
        }

        // POST: /Folder/Edit/5

        [HttpPost]
        public ActionResult EditFolder(FormCollection form, string saveChanges, string cancelChanges)
        {
            Tools toolbelt = new Tools();
            bool SuccessfulMove = toolbelt.moveFolder(WebSecurity.CurrentUserId, form["fid"], form["InFolderID"]);
            bool successfulNameChange = toolbelt.changeFolderName(WebSecurity.CurrentUserId, Convert.ToInt32(form["fid"]), form["FolderName"]);
            string errorMessage = "";
            if (!SuccessfulMove) { errorMessage += "<ERROR>This Edit Has Failed\nThe folder was not moved</ERROR>"; }
            if (!successfulNameChange) { errorMessage += "<ERROR>This Edit Has Failed\nThe folder name was not changed</ERROR>"; }
            ViewBag.UserID = new SelectList(dbContext.Users, "UserID", "UserName", WebSecurity.CurrentUserId);
            ViewBag.FolderID = new SelectList(dbContext.Folders, "FolderID", "FolderName", form["InFolderID"]);
            Response.Redirect("./../Home/Album?folderID=" + form["InFolderID"]);
            return PartialView();
        }
    }
}
