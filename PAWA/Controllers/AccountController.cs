using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace PAWA.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            if(Roles.IsUserInRole("User"))
            {
                Response.Redirect("/Home/Album");
            }
            else
            {
                Response.Redirect("/Admin/Index");
            }

            return View();
        }

        //
        // GET: /Account/CreateUser
        [HttpGet]
        [AllowAnonymous]
        public ActionResult CreateUser()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("PAWAContext", "User", "UserID", "Username", true);
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateUser(FormCollection form)
        {
            /* 
             *  Test Stub 
             */
            WebSecurity.CreateUserAndAccount(form["username"], form["password"], new { Email = "a@a.com", Country="USA", JoinDateTime = DateTime.Now, Status=1, DateOfBirth="12/12/2012", Gender=1, Password="A"});
            Response.Redirect("~/Account/Login");
            return View();
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if(!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("PAWAContext", "User", "UserID", "Username", true);
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection form)
        {
            bool success = WebSecurity.Login(form["username"], form["password"], false);

            if (success)
            {                       
                Response.Redirect("~/Account/Index");
            }

            return View();
        }

        //
        // GET: /Account/AccountManagement
        [Authorize(Roles="User")]
        public ActionResult AccountManagement()
        {
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            Response.Redirect("~/Account/Login");
            return View();
        }
    }
}
