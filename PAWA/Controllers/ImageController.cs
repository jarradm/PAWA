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

        public ActionResult DisplayImage()
        {
            int UserID = 1;
            PAWAContext dbContext = new PAWAContext();

            IEnumerable<File> files = from f in dbContext.Files
                        where f.UserID == UserID
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

            return View(file);
        }

        //
        // GET: /Image/

        public ActionResult UploadImage()
        {
            return View();
        }
    }
}
