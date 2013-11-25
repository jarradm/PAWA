using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWA.Models;
using PAWA.DAL;
using System.Data;
using System.Drawing;

namespace PAWA.Classes
{
    public class AlbumGrid : Controller
    {
        PAWAContext dbContext;
        int _MaxColumns = 5;

        public AlbumGrid(PAWAContext dbc)
        {
            dbContext = dbc;
        }

        /*
         * Returns a collection of Folder objects of a single user,
         * based on current folder level
        */
        public IEnumerable<Folder> GetFolders(int? folderID)
        {
            var UserID = 1;
            IEnumerable<Folder> returnValue;
            try
            {
                returnValue = from f in dbContext.Folders
                              where f.UserID == UserID && (f.InFolderID == folderID || (f.InFolderID == null && folderID == null))
                              select f;
            }
            catch (Exception e)
            {
                returnValue = (new HashSet<Folder> { });
                System.Diagnostics.Debug.WriteLine(e.InnerException);
            }

            return returnValue;
        }

        /*
         * Returns a collection of File objects of a single user,
         * based on the current folder level
        */
        public IEnumerable<File> GetFiles(int? folderID)
        {
            var UserID = 1;

            IEnumerable<File> returnValue;
            
            try
            {
                returnValue = from f in dbContext.Files
                              where f.UserID == UserID && (f.FolderID == folderID || (f.FolderID == null && folderID == null))
                              select f;
            }
            catch (Exception e)
            {
                returnValue = new HashSet<File> {  };
                System.Diagnostics.Debug.WriteLine(e.InnerException);
            }

            return returnValue;

        }

        /* 
         * Builds a table based on the amount of files and folders of the user.
         * 
         * Returns a string containing the html content to display on page.
        */
        public string CreateTable(int? folderID)
        {
            IEnumerable<Folder> folders = GetFolders(folderID);
            IEnumerable<File> files = GetFiles(folderID);
            string htmlOutput;
            int i, foldersIndex = 0, filesIndex = 0;
            bool exitFiles = false, exitFolders = false;

            htmlOutput = "<table id=\"body-content-table\">\n";
            while (!exitFiles)
            {
                htmlOutput += "<tr>\n";

                for (i = 0; i < _MaxColumns; i++)
                {
                    // Add folders to table
                    if (!exitFolders)
                    {
                        // no more folders at current level
                        if (foldersIndex >= folders.Count())
                        {
                            exitFolders = true;
                        }

                        if (!exitFolders)
                        {
                            htmlOutput += "<td>\n<a href=\"../Home/Album?folderID=" + folders.ElementAt(foldersIndex).FolderID + "\">" +
                            "<img src=\"../../Images/folder.png\" class=\"body-content-table-image\"/>\n" +
                            "<input type=\"checkbox\" class=\"body-content-table-checkbox\" id=\"" +
                            folders.ElementAt(foldersIndex).FolderID.ToString() + "_folder\" />\n" +
                            "<div class=\"body-content-table-folder-text\">" + folders.ElementAt(foldersIndex).FolderName +
                            "</div></a></td>";

                            foldersIndex++;
                        }
                    }

                    // Add files to table
                    if (exitFolders)
                    {
                        if (filesIndex >= files.Count())
                        {
                            exitFiles = true;
                        }

                        // fill the rest of the final row to maintain proper <td> width if there is only
                        // one row of data.
                        if (exitFiles)
                        {
                            htmlOutput += "<td>\n<span class=\"body-content-table-fakeimage\"/></span>\n"; ;
                        }
                        else
                        {
                            string[] fileExtension = {"void","file"};
                            if (files.ElementAt(filesIndex).Filename.Contains('.'))
                            {
                                fileExtension = files.ElementAt(filesIndex).Filename.Split('.');
                            }
                            htmlOutput += "<td>\n<a href=\"../../Image/DisplayImage?filename=" + files.ElementAt(filesIndex).Filename + 
                            "\"><img src=\"../../Images/User/" + fileExtension[0] + "_thumb." + fileExtension[1] + 
                            "\" class=\"body-content-table-image\"/>\n" +
                            "<input type=\"checkbox\" class=\"body-content-table-checkbox\" name=\"" + /* Input Checkbox with fileID as name and id */
                            files.ElementAt(filesIndex).FileID.ToString() + "\" id=\"" +
                            files.ElementAt(filesIndex).FileID.ToString() + "\" /></a>\n</td>";
                            
                            filesIndex++;
                        }
                    }
                }

                htmlOutput += "</tr>\n";
            }

            htmlOutput += "</table>\n";

            return htmlOutput;
        }
    }
}