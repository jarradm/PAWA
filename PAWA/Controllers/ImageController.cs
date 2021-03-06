﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.DAL;
using PAWA.Models;
using System.Drawing;
using PAWA.Classes;
using System.IO;
using WebMatrix.WebData;
using System.Data;
using Facebook;

namespace PAWA.Controllers
{
    [Authorize(Roles = "User")]
    public class ImageController : Controller
    {
        PAWAContext dbContext = new PAWAContext();

        //
        // GET: /Image/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Image/

        public ActionResult DisplayImage(string filename)
        {
            int UserID = WebSecurity.CurrentUserId;

            if (Request.QueryString["code"] != null)
            {
                SocialMediaTools socTools = new SocialMediaTools();
                var fb = new FacebookClient();
                string accessCode = Request.QueryString["code"].ToString();

                dynamic result = fb.Post("oauth/access_token", new
                {
                    client_id = "333143620161224", //This is my facebook APP ID
                    client_secret = "48a7bbdec0e82f32af25681980b288d0", //The APP's SECRET ID
                    redirect_uri = Request.Url.AbsoluteUri.ToString(),
                    code = accessCode //Code used to swap for Token

                });
                //Check result object for the token
                var accessToken = result.access_token;
                //Throw Token into a session, incase we might need later
                Session["AccessToken"] = accessToken;
                //Attach Token to Current Clients token paramater
                fb.AccessToken = accessToken;
                //Start Upload, passing filename and currently open client
                socTools.PostToFacebook(filename, fb);
                //Completed
                Response.Redirect("./../Home/Album");
                return View();
            }
            else
            {
                var files = from f in dbContext.Files
                            where f.UserID == UserID &&
                                  f.Filename == filename
                            select f;

                ViewBag.Tags = PAWA.Classes.DisplayImage.GetTags(dbContext, files.First().Tags);
                int value = files.SingleOrDefault().FileID;
                ViewBag.FolderId = files.SingleOrDefault().FolderID;

                return View(files.First());
            }
        }

        //
        // GET: /Image/

        public ActionResult UploadImage()
        {
            //Tools to call methods
            Tools funcs = new Tools();

            //temp user for authentication testing
            Tools.UserID = WebSecurity.CurrentUserId;

            //list used to generate DDL
            IList<Models.Folder> list = funcs.getFolders(Tools.UserID);


            /*True = Uploaded worked
            * False = Error
            * Null =  No action*/
            if (Tools.uploaded == true) { TempData["Uploaded"] = "File Uploaded Successfully!"; }
            else if (Tools.uploaded == false) 
            {
                var user = (from u in dbContext.Users
                            where u.UserID == WebSecurity.CurrentUserId
                            select u).SingleOrDefault();

                // user can't upload if account is frozen
                if (user.Status == Status.Frozen)
                {
                    TempData["Uploaded"] = "Couldn't upload,<br> your privileges have been suspended.";
                }
                else
                {
                    TempData["Uploaded"] = "File couldn't upload";
                }
            }
            else if (Tools.uploaded == null) { ViewData["Uploaded"] = " "; }

            //return list to view
            return View(list);
        }
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file, string FolderID, string description, string tags)
        {
            Tools funcs = new Tools();         //funcs contains resize/rename method
            Size newSize = new Size(181, 100); //global size for all thumbnails
            string[] TagArr;
            List<int> TagIDs;
            string finalTags;

            System.Drawing.Imaging.ImageFormat fileExtension;

            var user = (from u in dbContext.Users
                        where u.UserID == WebSecurity.CurrentUserId
                        select u).SingleOrDefault();

            // user can't upload if account is frozen
            if (user.Status == Status.Frozen)
            {
                Tools.uploaded = false;
                return RedirectToAction("UploadImage");
            }


            //Check file is valid
            if (funcs.PhotoValidation(file) == true)
            {

                //Declare filename and path
                var fileName = System.IO.Path.GetFileName(file.FileName);
                var path = "";

                //split tags
                TagArr = funcs.seperateTags(tags);

                //Checks if tag exists, if not adds it.
                TagIDs = funcs.checkIfTagExists(TagArr);

                //Converts the list array to a string and puts in ','
                finalTags = funcs.convertTagsToString(TagIDs);

                //Find filetype
                fileExtension = funcs.checkExtension(fileName);

                //Create encrypted fileName
                fileName = funcs.CreateFilename(Tools.UserID, fileName);

                //Path is directory  and filename
                path = System.IO.Path.Combine(Server.MapPath("~/Images/User/"), fileName);

                //save uploaded picture via path
                file.SaveAs(path);

                //temp image for thumb resize, so it doesnt overwrite the original image
                Image tempImage = System.Drawing.Image.FromFile(path);                

                //Create new database file using tempimage properties
                funcs.insertImageToDB(tempImage.Height, tempImage.Width, (int)(new System.IO.FileInfo(path).Length / 1000), fileName, finalTags, description, Convert.ToInt16(FolderID));

                //call resize on tempimage
                tempImage = funcs.ImageResize(tempImage, newSize); //resize tempimage using resize method in tools

                //save tempimage to server
                tempImage.Save(Server.MapPath("~/Images/User/" + fileName.Split('.')[0] + "_thumb." + fileName.Split('.')[1]), fileExtension); //save temp image

                //Clear connection to image
                tempImage.Dispose();

                Tools.uploaded = true;
            }
            //Error
            else { Tools.uploaded = false; }



            return RedirectToAction("UploadImage");
        }



        [HttpPost]
        public ActionResult DisplayImage(string fileName, string editImage, string deleteImage, string ShareToFacebook)
        {

            //If they want to delete
            if (deleteImage != null)
            {

                //Call Delete Method
                DeleteImage delImage = new DeleteImage();
                delImage.deleteSingleImage(Request, Server, fileName);

                //Navigate to album
                return RedirectToAction("./../Home/Album");
            }
            else if (editImage != null)
            {
                EditImage ei = new EditImage();
                int index = ei.GetID(fileName);
                return RedirectToAction("./../Image/UpdateImage", new{fileID = index}); ;
            }
                 //If they want to share to Facebook
            else if (ShareToFacebook != null)
            {
                SocialMediaTools SocTools = new SocialMediaTools();
                FacebookClient FBClient = new FacebookClient();

                //Create a custom query for facebook, they then return a in-url code which we exchange for a user token
                var loginUrl = FBClient.GetLoginUrl(new
                {
                    client_id = "333143620161224",
                    redirect_uri = (Request.Url.AbsoluteUri.ToString() + "?filename=" + fileName),
                    response_type = "code",
                    scope = "publish_actions,publish_stream"
                });
                //Reload the page and get a new Acess Token for this user --> Go to HTTPPOST
                Response.Redirect(loginUrl.AbsoluteUri);
                return View(fileName);
            }
            else
            
            {
                //Not deleting, do nothing
                return DisplayImage(fileName);
            }

        }

        public ActionResult UpdateImage(int fileID)
        {
            EditImage ei = new EditImage();
            PAWA.Models.File file = dbContext.Files.Find(fileID);
            if (file == null)
            {
                return HttpNotFound(fileID.ToString());
            }
            
            string tags = file.Tags.ToString();
            ViewBag.Tags = PAWA.Classes.DisplayImage.GetTags(dbContext, tags);
            ViewBag.FolderID = new SelectList(dbContext.Folders, "FolderID", "FolderName", file.FolderID);
            return View(file);
        }

        //
        // POST: /Image/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateImage(FormCollection form, string saveImage, string cancelImage)
        {
            EditImage ei = new EditImage();
            Tools tool = new Tools();

            int index = Convert.ToInt32(form["FileID"]);
            var files = from f in dbContext.Files where f.FileID == index select f;
            var file = files.First();

            file.Description = form["Description"];
            if (form["FolderID"] == "")
            ViewBag.FolderID = new SelectList(dbContext.Folders, "FolderID", "FolderName", file.FolderID);
            
            if (saveImage != null)
            {
                file.Tags = ei.stringOfTags(form);
                file.FolderID = ei.InFolderSetting(form["FolderID"]);

                if (ModelState.IsValid)
                {
                    dbContext.Entry(file).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return RedirectToAction("./../Image/DisplayImage", new { filename = form["Filename"] });
                }
                return View(file);
            }
            else 
            {
                return RedirectToAction("./../Image/DisplayImage", new { filename = form["Filename"] });
            }
        }

    }
}
