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
            System.Diagnostics.Debug.WriteLine(DropDownList);
            if (Submit != null && DropDownList.Equals("Delete"))
            {

                IEnumerable<File> files = GetFiles();
                int filesIndex = 0;
                string selectedValue;

                while (filesIndex < files.Count())
                {

                    selectedValue = Request.Form[files.ElementAt(filesIndex).FileID.ToString()];
                    int fileId = files.ElementAt(filesIndex).FileID;

                    if (selectedValue != null && selectedValue.Equals("on"))
                    {
                        System.Diagnostics.Debug.WriteLine("DEL");
                        
                        var dbContext = new PAWA.DAL.PAWAContext();
                        var deleteSelectedImages =
                            from File in dbContext.Files
                            where File.FileID == fileId
                            select File;
                        System.Diagnostics.Debug.WriteLine(deleteSelectedImages.Count());
                        if (deleteSelectedImages.Count() > 0)
                        {

                            System.Diagnostics.Debug.WriteLine("REMOVED");

                            dbContext.Files.Remove(deleteSelectedImages.First());
                        }

                        dbContext.SaveChanges();
                    }

                    filesIndex++;
                }

            }

            return View();
        }

        /*
         * Returns a collection of File objects of a single user,
         * based on the current folder level
        */
        public IEnumerable<File> GetFiles()
        {
            var dbContext = new PAWA.DAL.PAWAContext();

            var UserID = 1;

            var files = from f in dbContext.Files
                        where f.UserID == UserID
                        select f;

            return files;
        }
    }
}
