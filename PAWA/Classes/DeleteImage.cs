using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.Models;
using PAWA.DAL;
using System.Drawing;
using System.Data;
using WebMatrix.WebData;

namespace PAWA.Classes
{
    public class DeleteImage
    {
        PAWAContext dbContext;

        public void deleteSingleImage(HttpRequestBase Request, HttpServerUtilityBase Server, String fileName)
        {
            //Get the database connection
            dbContext = new PAWA.DAL.PAWAContext();
            
            //Get the file to delete from database
            PAWA.Models.File deleteFile = GetFile(fileName);

            //Delete the image file from server
            string[] fileExtension = deleteFile.Filename.Split('.');
            System.IO.File.Delete(Server.MapPath("~/Images/User/" + fileExtension[0] + "." + fileExtension[1]));
            System.IO.File.Delete(Server.MapPath("~/Images/User/" + fileExtension[0] + "_thumb." + fileExtension[1]));

            //Delete record from database
            dbContext.Files.Remove(deleteFile);
            dbContext.SaveChanges();
        }

        public void deleteMultipleImages(HttpRequestBase Request, HttpServerUtilityBase Server)
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
                    System.IO.File.Delete(Server.MapPath("~/Images/User/" + fileExtension[0] + "." + fileExtension[1]));
                    System.IO.File.Delete(Server.MapPath("~/Images/User/" + fileExtension[0] + "_thumb." + fileExtension[1]));

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


        /*
         * Returns a collection of File objects of a single user,
         * based on the current folder level
        */
        public IEnumerable<File> GetFiles()
        {

            var UserID = WebSecurity.CurrentUserId;

            //Search database for user files
            var files = from f in dbContext.Files
                        where f.UserID == UserID
                        select f;

            //return all
            return files;
        }

        /*
         * Returns a collection of File objects of a single user,
         * based on the current folder level
        */
        public PAWA.Models.File GetFile(string filename)
        {

            var UserID = WebSecurity.CurrentUserId;

            //Search database for file
            var files = from f in dbContext.Files
                        where f.UserID == UserID &&
                              f.Filename == filename
                        select f;

            //return first found
            return files.First();
        }
    }
}