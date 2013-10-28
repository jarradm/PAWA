using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.DAL;
using PAWA.Models;

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

            /*
            IEnumerable<File> files = from f in dbContext.Files
                        where f.UserID == UserID &&
                              f.Filename == filename
                        select f;
             */

            var files = from f in files1
                        where f.UserID == UserID &&
                              f.Filename == filename
                        select f;

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
            return View();
        }
    }
}
