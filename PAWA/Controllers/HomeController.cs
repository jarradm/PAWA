﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.Models;
using PAWA.DAL;
using PAWA.Classes;
using System.Drawing;
using System.Data;

namespace PAWA.Controllers
{
    public class HomeController : Controller
    {
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
            ViewBag.FolderID = folderID;

            return View();
        }

        public string GetAlbumList() {
            int UserID = 1;
            String returnValue;

            PAWAContext dbContext = new PAWAContext();
            var folders = from f in dbContext.Files
                          where f.UserID == UserID
                          select f.Folder;
            returnValue = folders.ToString();
            return returnValue;
        }


        [HttpPost]
        public ActionResult Album(string DropDownList, string Submit)
        {
            //If the go button was pushed and the dropdown was delete
            if (Submit != null && DropDownList.Equals("Delete"))
            {
                //Call Delete Method
                DeleteImage deleteImage = new DeleteImage();
                deleteImage.deleteMultipleImages(Request, Server);
            }
            if (Submit != null && DropDownList.Equals("Move")) 
            { 

            }
            //Re-load the view
            return View();
        }
    }
}
