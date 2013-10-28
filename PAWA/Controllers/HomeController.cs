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
            return View();
        }

        //
        // GET: /Home/AlbumTree

        public ActionResult Album()
        {
            return View();
        }
    }
}
