using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.Models;
using PAWA.DAL;
using System.Drawing;
using System.Data;

namespace PAWA.Controllers
{
    public class HomeController : Controller
    {
        PAWAContext dbContext;
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return RedirectToAction("Album");
        }

        //
        // GET: /Home/AlbumTree

        public ActionResult Album(int? folderID = null)
        {
            ViewBag.FolderID = folderID;

            return View();
        }


        [HttpPost]
        public ActionResult Album(string DropDownList, string Submit)
        {
            //If the go button was pushed and the dropdown was delete
            if (Submit != null && DropDownList.Equals("Delete"))
            {
                //Get the database connection
                dbContext = new PAWA.DAL.PAWAContext();

                //Get all files for the user
                IEnumerable<File> files = GetFiles();

                //For each file the user has
                int filesIndex = 0;
                string selectedValue;
                while (filesIndex < files.Count())
                {
                    //See  if this particular file was ticked
                    selectedValue = Request.Form[files.ElementAt(filesIndex).FileID.ToString()];
               
                    int fileId = files.ElementAt(filesIndex).FileID;

                    //If the file was selected
                    if (selectedValue != null && selectedValue.Equals("on"))
                    {
                        //Get this file object
                        File delFile = files.ElementAt(filesIndex);

                        //Delete the image file from server
                        string[] fileExtension = files.ElementAt(filesIndex).Filename.Split('.');
                        System.IO.File.Delete(Server.MapPath("~/Images/User/" + fileExtension[0] + ".jpg"));
                        System.IO.File.Delete(Server.MapPath("~/Images/User/" + fileExtension[0] + "_thumb.jpg"));

                        //Delete it from the database
                        dbContext.Files.Remove(delFile);
                        dbContext.SaveChanges();

                        //Don't go to next, the delete did that for us
                    }
                    else
                    {
                        //not selected, go to next
                        filesIndex++;
                    }
                }

            }

            //Re-load the view
            return View();
        }

        /*
         * Returns a collection of File objects of a single user,
         * based on the current folder level
        */
        public IEnumerable<File> GetFiles()
        {

            var UserID = 1;

            //Search database for user files
            var files = from f in dbContext.Files
                        where f.UserID == UserID
                        select f;

            //return all
            return files;
        }
    }
}
