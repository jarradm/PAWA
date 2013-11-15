using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.Models;
using PAWA.DAL;
using PAWA.Classes;
using System.Drawing;
using System.Data;

namespace PAWA.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult GetAlbumList(MoveFolder value) {
            int UserID=1;
            /*try
            {
                UserID = Convert.ToInt32(value.userID);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("eror: " + e);
                UserID = 1;
            }
            string returnValue = "";

            returnValue += "{";
            for (int i = 0; i < folderList.Count(); )
            {
                returnValue += i+":{FolderID:\""+i+"\",";
                returnValue += "FolderName:\"" + i + "\"},";
            }
            returnValue += "length:" + folderList.Count() + "}";*/

            PAWAContext dbContext = new PAWAContext();
            var folderList = from f in dbContext.Folders
                             where f.UserID == UserID
                             select f.Folders;

            return View();
        }


        [HttpPost]
        public ActionResult Album(string DropDownList, string Submit)
        {
            //If the go button was pushed and the dropdown was delete
            if (Submit != null && DropDownList.Equals("Delete"))
            {
                //Call Delete Method
                DeleteImage deleteImage = new DeleteImage();
                deleteImage.deleteMultipleImages(Request, Server);
            }
            if (Submit != null && DropDownList.Equals("Move")) 
            { 

            }
            //Re-load the view
            return View();
        }
    }
}
