using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.DAL;
using PAWA.Classes;
using PAWA.Models;
using System.IO;
using WebMatrix.WebData;
using System.Data;

namespace PAWA.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        PAWAContext dbContext = new PAWAContext();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            AdminReports ar = new AdminReports(dbContext);

            return View(ar);
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
            /* True = Tag Added
           * False = Error
           * Null = No action*/
            if (Tools.tagAdded == true) { ViewData["tagAdded"] = "Tag Added Sucessfully!"; }
            else if (Tools.tagAdded == false) { ViewData["tagAdded"] = "Tag couldn't Add"; }
            else if (Tools.tagAdded == null) { ViewData["tagAdded"] = " "; }

            return View(dbContext.Tags.ToList());
        }

        [HttpPost]
        public ActionResult TagManagement(string newTag)
        {
            Tools funcs = new Tools();

            if (newTag != "")
            {
                funcs.createTag(newTag, "admin");
                Tools.tagAdded = true;
            }
            else { Tools.tagAdded = false; }

            return RedirectToAction("TagManagement");
        }

        public ActionResult EditTag(int id)
        {
            Tools funcs = new Tools();
            PAWA.Models.Tags theTag = funcs.getTag(id);


            return View(theTag);
        }

        [HttpPost]
        public ActionResult EditTag([Bind(Include = "TagsID, TagName, Status, UserSuggest")]Models.Tags tag)
        {
            PAWAContext db = new PAWAContext();
            db.Tags.Attach(tag);
            var entry = db.Entry(tag);

            entry.Property(e => e.TagName).IsModified = true;
            entry.Property(e => e.Status).IsModified = true;
            entry.Property(e => e.UserSuggest).IsModified = true;

            db.SaveChanges();
            return RedirectToAction("TagManagement");
        }

        //
        // GET: /Admin/UserManagement

        public ActionResult UserManagement()
        {
            try
            {
                return View(dbContext.Users.ToList());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
                return View();
            }
        }


        public ActionResult FreezeUser(int id)
        {

            var User = dbContext.Users.Find(id);
            User.Status = Models.Status.Frozen;
            User.DeleteDateTime = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                dbContext.Entry(User).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("UserManagement");
            }
            return View(User);
        }

        public ActionResult DeleteUser(int id)
        {

            var User = dbContext.Users.Find(id);
            User.Status = Models.Status.Deleted;
            User.DeleteDateTime = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                dbContext.Entry(User).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("UserManagement");
            }
            return View(User);
        }

        public ActionResult EditUser(int id)
        {
            User user = dbContext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(FormCollection form, User user)
        {

            user.JoinDateTime = user.JoinDateTime;
            user.DateOfBirth = Convert.ToDateTime(form["DateOfBirth"]);
            if (user.Status.ToString() != "Active")
            {
                user.DeleteDateTime = System.DateTime.Now;
            }
            else
            {
                user.DeleteDateTime = null;
            }

            if (ModelState.IsValid)
            {
                dbContext.Entry(user).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("UserManagement");
            }
            return View(user);
        }

        public ViewResult ViewUser(string SearchString)
        {
            Tools funcs = new Tools();

            var users = from u in funcs.GetUsers()
                        select u;
            if (!String.IsNullOrEmpty(SearchString))
            {
                users = users.Where(u => u.UserID.ToString().Contains(SearchString) ||
                                         u.Username.Contains(SearchString));
            }


            return View(users);
        }

        public ActionResult ViewUserDetails(int id)
        {
            Tools funcs = new Tools();

            PAWA.Models.User TheUser = funcs.getUserByID(id);
            return View(TheUser);
        }
        public ActionResult MostUsedTagReport()
        {
            AdminReports reports = new AdminReports(dbContext);

            return View(reports);
        }

        //
        // GET: /Admin/MostPopularTagReport

        public ActionResult MostPopularTagReport()
        {
            AdminReports reports = new AdminReports(dbContext);

            return View(reports);
        }

        //
        // GET: /Admin/ImageUsageReport

        public ActionResult ImageUsageReport()
        {
            AdminReports reports = new AdminReports(dbContext);

            return View(reports);
        }

        //
        // GET: /Admin/VideoUsageReport

        public ActionResult VideoUsageReport()
        {
            AdminReports reports = new AdminReports(dbContext);

            return View(reports);
        }

        //
        // GET: /Admin/DailyUsageReport

        public ActionResult DailyUsageReport()
        {
            AdminReports reports = new AdminReports(dbContext);

            return View(reports);
        }

        //
        // GET: /Admin/ApplicationUsageReport

        public ActionResult ApplicationUsageReport()
        {
            AdminReports reports = new AdminReports(dbContext);

            return View(reports);
        }
    }
}
