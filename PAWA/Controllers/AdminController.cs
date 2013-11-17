using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.DAL;
using PAWA.Classes;

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
            //if tag string != nothing continue
            if (newTag != "")
            {
                //Create new tag object for insertion
                var TagObject = new PAWA.Models.Tags
                {
                    TagName = newTag,
                    FirstDateTime = System.DateTime.Now,
                    Status = Models.Status.Active,
                    UseCount = (int)0,
                    UserSuggest = Models.UserSuggest.Admin
                };
                //Add tag to Databsae
                dbContext.Tags.Add(TagObject);

                //Update DB
                dbContext.SaveChanges();

                //return successful tag add view
                Tools.tagAdded = true;
            }
            else
            {
                Tools.tagAdded = false;
            }

            return RedirectToAction("TagManagement");
        }

        //
        // GET: /Admin/UserManagement

        public ActionResult UserManagement()
        {
            return View();
        }

        //
        // GET: /Admin/MostUsedTagReport

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
