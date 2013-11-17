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

        public ActionResult GetAlbumList(UserIDType value) {
            int UserID=1;
            try
            {
                UserID = Convert.ToInt32(value.userID);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("eror: " + e);
                UserID = 1;
            }

            /*
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
            ViewBag.userID = UserID;
            return PartialView();
        }

        public ActionResult MoveImageTo(MoveItemList moveItemList)
        {
            PAWAContext dbContext = new PAWAContext();
            for (int i = 0; i < dbContext.Folders.Count(); i++)
            {
                if (dbContext.Folders.ElementAt(i).FolderID == Convert.ToInt32(moveItemList.destinationFolder) ) // User not passed across
                {

                    for (int n = 0; n < dbContext.Files.Count(); n++)
                    {
                        for (int j = 0; j < moveItemList.selected.Length; j++)
                        {
                            if (dbContext.Files.ElementAt(n).FileID == Convert.ToInt32(moveItemList.selected[j]))
                            {
                                dbContext.Files.ElementAt(j).FolderID = Convert.ToInt32(moveItemList.destinationFolder);
                                dbContext.SaveChanges();
                            }
                        }
                    }
                    return PartialView();
                }
            }
            return PartialView();
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
