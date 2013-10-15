using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAWA.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/ImageManagement

        public ActionResult ImageManagement()
        {
            return View();
        }

        //
        // GET: /Admin/TagManagement

        public ActionResult TagManagement()
        {
            return View();
        }

        //
        // GET: /Admin/UserManagement

        public ActionResult UserManagement()
        {
            return View();
        }

    }
}
