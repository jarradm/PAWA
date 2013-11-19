using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAWA.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/CreateUser

        public ActionResult CreateUser()
        {
            return View();
        }

        //
        // GET: /Account/Login

        public ActionResult Login()
        {
            return View();
        }

        //
        // GET: /Account/AccountManagement

        public ActionResult AccountManagement()
        {
            return View();
        }
    }
}
