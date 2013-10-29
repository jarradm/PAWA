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


        [HttpPost]
        public ActionResult Album(string Action, string Go)
        {
            if (Go != null && Action.Equals("Delete"))
            {
                //Delete from the database
                System.Diagnostics.Debug.WriteLine("DELETING!");
            }

            return View();
        }
    }
}
