﻿using System;
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
    public class FoldersController : Controller
    {
        static readonly IFolderRepository repository = new FolderRepository();

        public IEnumerable<Folder> GetAllFolders()
    {
        return repository.GetAll();
    }
        /*
        public Folder GetFolder(int id)
        {
            Folder item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        
        public HttpResponseMessage PostFolder(Folder item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Folder>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.FolderID });
            response.Headers.Location = new Uri(uri);
            return response;
        }*/
        [HttpPost]
        public ActionResult CreateFolder(string FolderName, int InFolderID)
        {
            Folder newFolder = new Folder();
            newFolder.UserID = 1;
            newFolder.FolderName = FolderName;
            newFolder.InFolderID = InFolderID;
            newFolder.CreateDateTime = DateTime.Now;

            return View();
        }
        /*
        public void PutFolder(int id, Folder folder)
        {
            folder.FolderID = id;
            if (!repository.Update(folder))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteFolder(int id)
        {
            repository.Remove(id);
        }
         * */


        //
        // GET: /Folders/
        /*
        public ActionResult Index()
        {
            return View();
        }
        */
    }
}