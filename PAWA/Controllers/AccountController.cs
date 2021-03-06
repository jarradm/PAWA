﻿using System;
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
using PAWA.Classes;
using System.Reflection;
using System.Globalization;
using PAWA.ViewModels;

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
            var userID = WebSecurity.CurrentUserId;

            var user = (from u in db.Users
                        where u.UserID == userID
                        select u).SingleOrDefault();

            if (user.Status == Status.Deleted || user.Status == Status.Inactive)
            {
                WebSecurity.Logout();
                return RedirectToAction("Index", new { d = "1" });
            }

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
            ViewBag.CountryList = GetCountries();
            return View();
        }
        public ActionResult Close()
        {
            var user = db.Users.Where(u => u.UserID == WebSecurity.CurrentUserId).SingleOrDefault();
            user.Status = PAWA.Models.Status.Inactive;
            user.DeleteDateTime = System.DateTime.Now;
            if (ModelState.IsValid == true)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Login("0");
        }



        [HttpPost]
        public ActionResult _ExistingUser(string Username)
        {
            string returnValue = "ok";
            User user = (from u in db.Users
                         where u.Username == Username
                         select u).SingleOrDefault();

            if (user != null)
            {
                returnValue = "User Already Exists";
            }
            return Content(returnValue);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreateUser(User user)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(user.Username, user.Password, new
                    {
                        Email = user.Email,
                        Country = user.Country,
                        JoinDateTime = DateTime.Now,
                        Status = Status.Active,
                        DateOfBirth = user.DateOfBirth.ToString("dd-MM-yyyy"),
                        Gender = user.Gender,
                        Password = "notused"
                    });
                    Roles.AddUserToRole(user.Username, "user");

                    return RedirectToAction("../Home/Album");
                }
                catch
                {
                }
            }
            ViewBag.CountryList = GetCountries();
            return View(user);
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string d = "0")
        {
            
            LoginViewModel lvm = new LoginViewModel
            {
                Username = "",
                Password = ""
            };

            // user has tried to login to deleted account
            if (d == "1")
            {
                ModelState.AddModelError("DeletedUser", "Invalid login: Account has been deleted.");
            }
  
            return View(lvm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                bool success = WebSecurity.Login(lvm.Username, lvm.Password, false);

                if (success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("IncorrectLogin", "Incorrect Username/Password Combination!");
                }
            }

            return View(lvm);
        }
                
        public ActionResult NewLogin()
        {
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
        
        //
        // GET: /Account/EditUser

        [HttpGet]
        [Authorize]
        public ActionResult EditUser()
        {
            // WebSecurity.CurrentUserId gets logged in user, UserID 
            var user = db.Users.Where(u => u.UserID == WebSecurity.CurrentUserId).SingleOrDefault();
            var uvm = new UserViewModel
            {
                UserID = user.UserID,
                Email = user.Email,
                Country = user.Country,
                Gender = user.Gender,
                OldPassword = user.Password
            };

            ViewBag.CountryList = GetCountries();
            return View(uvm);
        }

        //
        // POST: /Account/EditUser

        public IEnumerable<SelectListItem> GetCountries()
        {
            RegionInfo country = new RegionInfo(new CultureInfo("en-US", false).LCID);
            List<SelectListItem> countryNames = new List<SelectListItem>();

            //To get the Country Names from the CultureInfo installed in windows
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                country = new RegionInfo(cul.LCID);
                countryNames.Add(new SelectListItem() { Text = country.DisplayName, Value = country.DisplayName });
            }
            
            //Assigning all Country names to IEnumerable
            IEnumerable<SelectListItem> nameAdded = countryNames.GroupBy(x => x.Text).Select(x => x.FirstOrDefault()).ToList<SelectListItem>().OrderBy(x => x.Text);
            return nameAdded;
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditUser(string button, UserViewModel uvm)
        {
            var user = db.Users.Where(u => u.UserID == 2).SingleOrDefault();

            ViewBag.CountryList = GetCountries();

            if (button == "cancel")
            {
                return RedirectToAction("Details");
            }
            else if (button == "delete")
            {
                Close();
                return RedirectToAction("Login");
            }
            if (button == "submit")
            {
                if (ModelState.IsValid == true)
                {

                    user.Email = uvm.Email;

                    // Check if password entered into OldPassword field
                    if (!String.IsNullOrEmpty(uvm.OldPassword))
                    {
                        // Don't want to change password to an empty password
                        if (String.IsNullOrEmpty(uvm.Password))
                        {
                            ModelState.AddModelError("Password", "Password is required");
                            return View(uvm);
                        }

                        // Change password
                        if (!WebSecurity.ChangePassword(WebSecurity.CurrentUserName, uvm.OldPassword, uvm.ConfirmPassword))
                        {
                            ModelState.AddModelError("OldPassword", "Old password incorrect.");
                        }
                    }

                    user.Gender = uvm.Gender;
                    user.Country = uvm.Country;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Details");
                }
                else
                {
                    db.GetValidationErrors();

                }

            }
            return View(uvm);
        }

        [Authorize(Roles="User")]
        public ActionResult Details()
        {
            User user = db.Users.Find(WebSecurity.CurrentUserId);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        //
        // POST: Account/Login

        [HttpPost]
        public ActionResult Cancel()
        {
            return RedirectToAction("Home", "Account");
        }

        //
        // GET: /Account/Delete/

        [HttpGet]
        [Authorize]
        public ActionResult Delete(FormCollection collection)
        {
            try
            {
                var user = db.Users.Where(u => u.UserID == WebSecurity.CurrentUserId).SingleOrDefault();

                user.Status = PAWA.Models.Status.Inactive;
                user.DeleteDateTime = DateTime.Now;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }
    }
}
