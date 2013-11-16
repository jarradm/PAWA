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
        PAWAContext db = new PAWAContext();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            AdminReports ar = new AdminReports(db);

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

            return View(db.Tags.ToList());
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
                db.Tags.Add(TagObject);

                //Update DB
                db.SaveChanges();

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

    }
}
