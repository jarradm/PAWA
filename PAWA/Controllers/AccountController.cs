using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.DAL;
using PAWA.Classes;
using System.Data.Entity;
using System.Reflection;
using System.Data;
using System.Globalization;
using PAWA.ViewModels;

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
                
        public ActionResult NewLogin()
        {
            return View();
        }

        //
        // GET: /Account/AccountManagement

        public ActionResult AccountManagement()
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
        public ActionResult EditUser(string button, UserViewModel uvm, FormCollection fc)
        {
            PAWAContext dbContext = new PAWAContext();
            
            var user = dbContext.Users.Where(u => u.UserID == 2).SingleOrDefault();
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
                    dbContext.GetValidationErrors();
                }
                dbContext.Entry(user).State = EntityState.Modified;
                dbContext.SaveChanges();

            }
            return View(uvm);

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
