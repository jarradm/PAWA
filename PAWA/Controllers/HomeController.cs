using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult AlbumTree()
        {
            return View();
        }

        //
        // GET: /Home/AlbumGrid

        public ActionResult AlbumGrid()
        {
            return View();
        }
    }
}
