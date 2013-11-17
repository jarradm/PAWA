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
using PAWA.ViewModels;

namespace PAWA.Controllers
{
    [Authorize(Roles="User")]
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
            int userid = 11;
            int tid = 7;
            int? fid = null;
            string t_id = "4";
            
            var tpc = new TestPAWAContext
            {
                Folders =
                {
                    new Folder { UserID = 11, InFolderID = null, 
                    CreateDateTime = DateTime.Parse("2013/08/28 13:21:50"), 
                    FolderName = "Australian Holiday" },
                    new Folder { UserID = 11, InFolderID = null, 
                    CreateDateTime = DateTime.Parse("2013/08/28 13:21:50"), 
                    FolderName = "Australian Holiday" },
                    new Folder { UserID = 11, InFolderID = null, 
                    CreateDateTime = DateTime.Parse("2013/08/28 13:21:50"), 
                    FolderName = "Australian Holiday" },
                    new Folder { UserID = 11, InFolderID = null, 
                    CreateDateTime = DateTime.Parse("2013/08/28 13:21:50"), 
                    FolderName = "Australian Holiday" },
                    new Folder { UserID = 11, InFolderID = null, 
                    CreateDateTime = DateTime.Parse("2013/08/28 13:21:50"), 
                    FolderName = "Australian Holiday" },
                    new Folder { UserID = 11, InFolderID = null, 
                    CreateDateTime = DateTime.Parse("2013/08/28 13:21:50"), 
                    FolderName = "Australian Holiday" },
                },

                Files =
                {
                    new File { UserID = userid, TypeID = tid, FolderID = fid, Tags = t_id, 
                    Filename = "39237a426ae7e39182ea4c286cb3c250bde66ccba0b9b9944e5a7818a1a0a49e.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:15"), 
                    Description = "A killer koala, seen in its natural habit waiting for its prey.", 
                    SizeMB = 780, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "3ab28c4f18e4daee52ffa4587016ba491c45812d7d1051e24b191648b3d152e7.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:25"), 
                    Description = "That flower that's hard to say and even harder to spell...but they make great tea.", 
                    SizeMB = 879, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "1b3a3eb3fda1e33ae12a954a3e433557de17ea2bb04990a332b1015e7df638c8.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:35"), 
                    Description = "Desert.", 
                    SizeMB = 845, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "38ab90242284a5106e273e406efe84f533f652ca5fa51d30f11af581f2c032ad.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:45"), 
                    Description = "Flower.", 
                    SizeMB = 595, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "82579f271ca76ddae60732c761804e0a090e8dd6fd85e9d43dfab981cb881567.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:55"), 
                    Description = "The invasion has begun.", 
                    SizeMB = 775, SizeHeight = 768, SizeWidth = 1024 },

                    new File { UserID = userid, TypeID = tid, FolderID = fid, Tags = t_id, 
                    Filename = "39237a426ae7e39182ea4c286cb3c250bde66ccba0b9b9944e5a7818a1a0a49e.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:15"), 
                    Description = "A killer koala, seen in its natural habit waiting for its prey.", 
                    SizeMB = 780, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "3ab28c4f18e4daee52ffa4587016ba491c45812d7d1051e24b191648b3d152e7.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:25"), 
                    Description = "That flower that's hard to say and even harder to spell...but they make great tea.", 
                    SizeMB = 879, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "1b3a3eb3fda1e33ae12a954a3e433557de17ea2bb04990a332b1015e7df638c8.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:35"), 
                    Description = "Desert.", 
                    SizeMB = 845, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "38ab90242284a5106e273e406efe84f533f652ca5fa51d30f11af581f2c032ad.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:45"), 
                    Description = "Flower.", 
                    SizeMB = 595, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "82579f271ca76ddae60732c761804e0a090e8dd6fd85e9d43dfab981cb881567.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:55"), 
                    Description = "The invasion has begun.", 
                    SizeMB = 775, SizeHeight = 768, SizeWidth = 1024 },

                    new File { UserID = userid, TypeID = tid, FolderID = fid, Tags = t_id, 
                    Filename = "39237a426ae7e39182ea4c286cb3c250bde66ccba0b9b9944e5a7818a1a0a49e.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:15"), 
                    Description = "A killer koala, seen in its natural habit waiting for its prey.", 
                    SizeMB = 780, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "3ab28c4f18e4daee52ffa4587016ba491c45812d7d1051e24b191648b3d152e7.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:25"), 
                    Description = "That flower that's hard to say and even harder to spell...but they make great tea.", 
                    SizeMB = 879, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "1b3a3eb3fda1e33ae12a954a3e433557de17ea2bb04990a332b1015e7df638c8.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:35"), 
                    Description = "Desert.", 
                    SizeMB = 845, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "38ab90242284a5106e273e406efe84f533f652ca5fa51d30f11af581f2c032ad.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:45"), 
                    Description = "Flower.", 
                    SizeMB = 595, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "82579f271ca76ddae60732c761804e0a090e8dd6fd85e9d43dfab981cb881567.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:55"), 
                    Description = "The invasion has begun.", 
                    SizeMB = 775, SizeHeight = 768, SizeWidth = 1024 },

                    new File { UserID = userid, TypeID = tid, FolderID = fid, Tags = t_id, 
                    Filename = "39237a426ae7e39182ea4c286cb3c250bde66ccba0b9b9944e5a7818a1a0a49e.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:15"), 
                    Description = "A killer koala, seen in its natural habit waiting for its prey.", 
                    SizeMB = 780, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "3ab28c4f18e4daee52ffa4587016ba491c45812d7d1051e24b191648b3d152e7.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:25"), 
                    Description = "That flower that's hard to say and even harder to spell...but they make great tea.", 
                    SizeMB = 879, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "1b3a3eb3fda1e33ae12a954a3e433557de17ea2bb04990a332b1015e7df638c8.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:35"), 
                    Description = "Desert.", 
                    SizeMB = 845, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "38ab90242284a5106e273e406efe84f533f652ca5fa51d30f11af581f2c032ad.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:45"), 
                    Description = "Flower.", 
                    SizeMB = 595, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "82579f271ca76ddae60732c761804e0a090e8dd6fd85e9d43dfab981cb881567.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:55"), 
                    Description = "The invasion has begun.", 
                    SizeMB = 775, SizeHeight = 768, SizeWidth = 1024 },

                    new File { UserID = userid, TypeID = tid, FolderID = fid, Tags = t_id, 
                    Filename = "39237a426ae7e39182ea4c286cb3c250bde66ccba0b9b9944e5a7818a1a0a49e.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:15"), 
                    Description = "A killer koala, seen in its natural habit waiting for its prey.", 
                    SizeMB = 780, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "3ab28c4f18e4daee52ffa4587016ba491c45812d7d1051e24b191648b3d152e7.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:25"), 
                    Description = "That flower that's hard to say and even harder to spell...but they make great tea.", 
                    SizeMB = 879, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "1b3a3eb3fda1e33ae12a954a3e433557de17ea2bb04990a332b1015e7df638c8.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:35"), 
                    Description = "Desert.", 
                    SizeMB = 845, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "38ab90242284a5106e273e406efe84f533f652ca5fa51d30f11af581f2c032ad.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:45"), 
                    Description = "Flower.", 
                    SizeMB = 595, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "82579f271ca76ddae60732c761804e0a090e8dd6fd85e9d43dfab981cb881567.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:55"), 
                    Description = "The invasion has begun.", 
                    SizeMB = 775, SizeHeight = 768, SizeWidth = 1024 },

                    new File { UserID = userid, TypeID = tid, FolderID = fid, Tags = t_id, 
                    Filename = "39237a426ae7e39182ea4c286cb3c250bde66ccba0b9b9944e5a7818a1a0a49e.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:15"), 
                    Description = "A killer koala, seen in its natural habit waiting for its prey.", 
                    SizeMB = 780, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "3ab28c4f18e4daee52ffa4587016ba491c45812d7d1051e24b191648b3d152e7.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:25"), 
                    Description = "That flower that's hard to say and even harder to spell...but they make great tea.", 
                    SizeMB = 879, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "1b3a3eb3fda1e33ae12a954a3e433557de17ea2bb04990a332b1015e7df638c8.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:35"), 
                    Description = "Desert.", 
                    SizeMB = 845, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "38ab90242284a5106e273e406efe84f533f652ca5fa51d30f11af581f2c032ad.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:45"), 
                    Description = "Flower.", 
                    SizeMB = 595, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "82579f271ca76ddae60732c761804e0a090e8dd6fd85e9d43dfab981cb881567.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:55"), 
                    Description = "The invasion has begun.", 
                    SizeMB = 775, SizeHeight = 768, SizeWidth = 1024 },
                    new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "3ab28c4f18e4daee52ffa4587016ba491c45812d7d1051e24b191648b3d152e7.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:25"), 
                    Description = "That flower that's hard to say and even harder to spell...but they make great tea.", 
                    SizeMB = 879, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "1b3a3eb3fda1e33ae12a954a3e433557de17ea2bb04990a332b1015e7df638c8.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:35"), 
                    Description = "Desert.", 
                    SizeMB = 845, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "38ab90242284a5106e273e406efe84f533f652ca5fa51d30f11af581f2c032ad.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:45"), 
                    Description = "Flower.", 
                    SizeMB = 595, SizeHeight = 768, SizeWidth = 1024 },

                new File { UserID = userid, TypeID = tid, FolderID = null, Tags = t_id.Split(',')[0], 
                    Filename = "82579f271ca76ddae60732c761804e0a090e8dd6fd85e9d43dfab981cb881567.jpg", UploadedDateTime = DateTime.Parse("2013/08/27 17:16:55"), 
                    Description = "The invasion has begun.", 
                    SizeMB = 775, SizeHeight = 768, SizeWidth = 1024 }
                }
            };
            AlbumViewModel avm = new AlbumViewModel(tpc);
            avm.FolderID = folderID;
            //ViewBag.FolderID = folderID;

            return View(avm);
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

            //Re-load the view
            return View();
        }
    }
}
