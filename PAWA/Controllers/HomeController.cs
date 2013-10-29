using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.Classes;
using PAWA.DAL;

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
    }
}
