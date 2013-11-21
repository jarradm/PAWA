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
        
        public ActionResult NewLogin()
        {
            return View();
        }

        //
        // GET: /Account/EditUser

        [HttpGet]
        public ActionResult EditUser()
        {
            PAWAContext dbContext = new PAWAContext();

            var user = dbContext.Users.Where(u => u.UserID == 2).SingleOrDefault();

            return View(user);
        }

        //
        // POST: /Account/EditUser


        [HttpPost]
        public ActionResult EditUser(string button, FormCollection fc, string confirmPass, string pass)
        {
            PAWAContext dbContext = new PAWAContext();
            var user = dbContext.Users.Where(u => u.UserID == 2).SingleOrDefault();
            string password = pass;
            string confirmPassword = confirmPass;
            var email = fc.Get(1).ToString();

            if (button == "cancel")
            {
                return RedirectToAction("Login", "Account");
            }
            else if (button == "delete")
            {
                return RedirectToAction("Delete", "Account");
            }
            if (button == "submit")
            {
                TryUpdateModel(user, fc);
                if (ModelState.IsValid == true)
                {
                    if (password != "" && confirmPassword != "")
                    {
                        if (password == confirmPassword && password != "")
                        {
                            user.Password = password;
                            dbContext.Entry(user).State = EntityState.Modified;
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            dbContext.GetValidationErrors();
                        }
                    }
                    else
                    {
                        dbContext.GetValidationErrors();
                    }
                    if (email != "" || email != "" && password == confirmPassword)
                    {
                        user.Email = email;
                        dbContext.Entry(user).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        dbContext.GetValidationErrors();
                    }
                }
                else
                {
                    dbContext.GetValidationErrors();
                }
            }
            return View(user);

        }

        //
        // Country: Drop Down List


        //
        // POST: Account/Login

        [HttpPost]
        public ActionResult Cancel()
        {
            return RedirectToAction("Login");
        }

        //
        // GET: /Account/Delete/

        [HttpGet]
        public ActionResult Delete(FormCollection collection)
        {
            PAWAContext dbContext = new PAWAContext();
            try
            {
                var user = dbContext.Users.Where(u => u.UserID == 2).SingleOrDefault();

                dbContext.Users.Remove(user);
                //Dangerous Code: dbContext.SaveChanges();

                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }
    }
}
