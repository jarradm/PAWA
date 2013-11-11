﻿using System;
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
            return View();
        }

        //
        // GET: /Account/CreateUser
        [HttpGet]
        public ActionResult CreateUser()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("PAWAContext", "User", "UserID", "Username", true);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            
            WebSecurity.CreateUserAndAccount(form["username"], form["password"], new { Email = "a@a.com", Country="USA", JoinDateTime = DateTime.Now, Status=1, DateOfBirth="12/12/2012", Gender=1, Password="A"});
            Response.Redirect("~/Account/Login");
            return View();
        }

        //
        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            if(!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("PAWAContext", "User", "UserID", "Username", true);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            bool success = WebSecurity.Login(form["username"], form["password"], false);

            if (success)
            {
                Response.Redirect("~/Home/Album");
            }

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
