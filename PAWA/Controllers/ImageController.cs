using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.DAL;
using PAWA.Models;
using System.Drawing;
using PAWA.Classes;


namespace PAWA.Controllers
{
    public class ImageController : Controller
    {
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
            int UserID = 1;
            PAWAContext dbContext = new PAWAContext();

            var files1 = new List<File>
            {
                new File { UserID = 1, TypeID = 1, FolderID = 2, Tags = "1,2", 
                    Filename = "Koala.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:15"), 
                    Description = "A killer koala, seen in its natural habit waiting for its prey.", 
                    SizeMB = 3500, SizeHeight = 680, SizeWidth = 1048 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "Chrysanthemum.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:19"), 
                    Description = "That flower that's hard to say and even harder to spell...but they make great tea.", 
                    SizeMB = 3478, SizeHeight = 680, SizeWidth = 1048 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "Desert.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:19"), 
                    Description = "Desert.", 
                    SizeMB = 3478, SizeHeight = 680, SizeWidth = 1048 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "Hydrangeas.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:19"), 
                    Description = "Flower.", 
                    SizeMB = 3478, SizeHeight = 680, SizeWidth = 1048 },

                new File { UserID = 1, TypeID = 1, FolderID = null, Tags = "1", 
                    Filename = "Jellyfish.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:19"), 
                    Description = "The invasion has begun.", 
                    SizeMB = 3478, SizeHeight = 680, SizeWidth = 1048 }
            };

            
            var files = from f in dbContext.Files
                        where f.UserID == UserID &&
                              f.Filename == filename
                        select f;
             
            /*
            var files = from f in files1
                        where f.UserID == UserID &&
                              f.Filename == filename
                        select f;
             */

            var file = new File
            {
                UserID = 1,
                TypeID = 1,
                FolderID = 2,
                Tags = "1,2",
                Filename = "Koala.jpg",
                UploadedDateTime = DateTime.Parse("2013/08/27 17:16:15"),
                Description = "Sydney Harbour as seen from the peak of the Sydney Harbour Bridge",
                SizeMB = 3500,
                SizeHeight = 680,
                SizeWidth = 1048
            };

            return View(files.SingleOrDefault());
        }

        //
        // GET: /Image/

        public ActionResult UploadImage()
        {
            //Tools to call methods
            Tools funcs = new Tools();

            //temp user for authentication testing
            Tools.UserID = 1;

            //list used to generate DDL
            IList<Models.Folder> list = funcs.getFolders(Tools.UserID);


            /*True = Uploaded worked
            * False = Error
            * Null =  No action*/
            if (Tools.uploaded == true) { ViewData["Uploaded"] = "File Uploaded Sucessfully!"; }
            else if (Tools.uploaded == false) { ViewData["Uploaded"] = "File couldn't upload"; }
            else if (Tools.uploaded == null) { ViewData["Uploaded"] = " "; }

            //return list to view
            return View(list);
        }
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file, string FolderID, string newName, string description, string tags)
        {
            PAWAContext db = new PAWAContext();
            Tools funcs = new Tools();         //funcs contains resize/rename method
            Tools.UserID = 1;
            Size newSize = new Size(181, 100); //global size for all thumbnails
            System.Drawing.Imaging.ImageFormat fileExtension;


            //Start upload
            if (file != null)
            {
                //Declare filename and path
                var fileName = System.IO.Path.GetFileName(file.FileName);
                var path = "";

                //rename file?
                if (newName != "")
                {
                    fileName = funcs.Rename(fileName, newName);
                }

                //split tags
                if (tags.Contains(','))
                {
                    tags = funcs.seperateTags(tags);
                }

                //Find filetype
                fileExtension = funcs.checkExtension(fileName);
                fileName = funcs.CreateFilename(Tools.UserID, fileName); 

                //Path is directory  and filename
                path = System.IO.Path.Combine(Server.MapPath("~/Images/User/"), fileName);

                //save uploaded picture via path
                file.SaveAs(path);

                //temp image for thumb resize, so it doesnt overwrite the original image
                Image tempImage = System.Drawing.Image.FromFile(path);

                //Create new database file using tempimage properties
                var ImageFile = new PAWA.Models.File
                {
                    UploadedDateTime = System.DateTime.Now,
                    SizeHeight = (int)tempImage.Height,
                    SizeWidth = (int)tempImage.Width,
                    SizeMB = (int)(new System.IO.FileInfo(path).Length / 1000),
                    Filename = fileName,
                    Tags = tags,
                    Description = description,

                    //Required
                    TypeID = 1,
                    UserID = Tools.UserID,
                    FolderID = Convert.ToInt16(FolderID)

                };
                //Insert file into database
                db.Files.Add(ImageFile);
                db.SaveChanges();

                //call resize on tempimage
                tempImage = funcs.ImageResize(tempImage, newSize); //resize tempimage using resize method in tools

                //save tempimage to server
                tempImage.Save(Server.MapPath("~/Images/User/" + fileName.Split('.')[0] + "_thumb." + fileName.Split('.')[1]), fileExtension); //save temp image

                //.jpg .png .bmp
                //Clear connection to image
                tempImage.Dispose();

                /*  Testing
                //ImageFile Properties
                System.Diagnostics.Debug.WriteLine(ImageFile.Filename);
                System.Diagnostics.Debug.WriteLine(ImageFile.Tags);
                System.Diagnostics.Debug.WriteLine(ImageFile.Description);
                System.Diagnostics.Debug.WriteLine(ImageFile.UploadedDateTime);
                System.Diagnostics.Debug.WriteLine(ImageFile.SizeHeight);
                System.Diagnostics.Debug.WriteLine(ImageFile.SizeWidth);
                System.Diagnostics.Debug.WriteLine(ImageFile.SizeMB);
                System.Diagnostics.Debug.WriteLine("Type ID: " + ImageFile.TypeID);
                System.Diagnostics.Debug.WriteLine("Folder ID: " +ImageFile.FolderID);
                System.Diagnostics.Debug.WriteLine("User ID:" + ImageFile.UserID);
                */
                //Return sucessfull upload view
                Tools.uploaded = true;
            }
            //Error, couldnt upload for w/e reason...
            else { Tools.uploaded = false; }



            return RedirectToAction("UploadImage");
        }
    }
}
