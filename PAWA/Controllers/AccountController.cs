using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using PAWA.Models;
using PAWA.DAL;

namespace PAWA.Controllers
{
    public class AccountController : Controller
    {
        private PAWAContext db = new PAWAContext();
        //
        // GET: /Account/
        [Authorize]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.JoinDateTime = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("../Home/Album");
            }

            return View(user);
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

        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}
