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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreateUser(User user)
        {

            if (ModelState.IsValid)
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
            ViewBag.CountryList = GetCountries();
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
                Password = user.Password
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
                country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                countryNames.Add(new SelectListItem() { Text = country.DisplayName, Value = country.DisplayName });
            }
            
            //Assigning all Country names to IEnumerable
            IEnumerable<SelectListItem> nameAdded = countryNames.GroupBy(x => x.Text).Select(x => x.FirstOrDefault()).ToList<SelectListItem>().OrderBy(x => x.Text);
            return nameAdded;
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditUser(string button, UserViewModel uvm, FormCollection fc)
        {            
            var user = db.Users.Where(u => u.UserID == 2).SingleOrDefault();
            string password = fc.Get(2).ToString();
            string confirmPassword = fc.Get(3).ToString();
            string email = fc.Get(1).ToString();
            string country = fc.Get(4).ToString();
            
            //return Content("Password: " + password + "Confirmpassword: " + confirmPassword + "Email: " + email + "Country: " + country + "Gender: " + uvm.Gender);

            ViewBag.CountryList = GetCountries();

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
                TryUpdateModel(uvm);
                if (ModelState.IsValid == true)
                {
                    if (!String.IsNullOrEmpty(email))
                        user.Email = uvm.Email;
                    if (String.IsNullOrEmpty(email))
                        user.Email = user.Email;
                    if (String.IsNullOrEmpty(password))
                        user.Password = user.Password;
                    if (password == confirmPassword)
                    {
                        uvm.Password = password;
                        user.Password = uvm.Password;
                    }
                    PAWA.Models.Gender g = (PAWA.Models.Gender)Enum.Parse(typeof(PAWA.Models.Gender), fc.Get(5));
                    user.Gender = g;
                    user.Country = uvm.Country;
                }
                else
                {
                    db.GetValidationErrors();
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

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
            return RedirectToAction("Login");
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

                db.Users.Remove(user);
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
