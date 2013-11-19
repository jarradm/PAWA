using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.Models;
using PAWA.DAL;

namespace PAWA.Controllers
{
    public class AccountController : Controller
    {
        private PAWAContext db = new PAWAContext();
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /Account/CreateUser

        public ActionResult CreateUser()
        {
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
