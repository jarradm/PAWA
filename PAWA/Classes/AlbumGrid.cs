using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAWA.Models;
using PAWA.DAL;
using System.Data;

namespace PAWA.Classes
{
    public class AlbumGrid
    {
        PAWAContext dbContext;

        public AlbumGrid(PAWAContext dbc)
        {
            dbContext = dbc;
        }

        public IEnumerable<Folder> GetFolders()
        {
            var UserID = 1;

            var folders = from f in dbContext.Folders
                          where f.UserID == UserID
                          select f;             

            return folders;
        }

        public IEnumerable<File> GetFiles(int? folderID)
        {
            var UserID = 1;

            var files = from f in dbContext.Files
                        where f.UserID == UserID && (f.FolderID == folderID || (f.FolderID == null && folderID == null))
                        select f;            

            return files;
        }

        /* 
         * Builds a table based on the amount of files and folders of the user.
         * 
         * Returns a string containing the html content to display on page.
        */
        public string CreateTable(int? folderID)
        {
            IEnumerable<Folder> folders = GetFolders();
            IEnumerable<File> files = GetFiles(folderID);
            string htmlOutput;
            int i, foldersIndex = 0, filesIndex = 0;
            bool exitFiles = false, exitFolders = false;

            htmlOutput = "<table id=\"body-content-table\">\n";
            while (!exitFiles)
            {
                htmlOutput += "<tr>\n";

                for (i = 0; i < 5; i++)
                {
                    // Add folders to table
                    if (!exitFolders)
                    {
                        if (foldersIndex >= folders.Count())
                        {
                            exitFolders = true;
                        }

                        if(!exitFolders)
                        {
                            htmlOutput += "<td>\n<img src=\"../../Images/folder.png\" class=\"body-content-table-image\"/>\n" +
                            "<input type=\"checkbox\" class=\"body-content-table-checkbox\" id=\"" +
                            folders.ElementAt(foldersIndex).FolderID.ToString() + "_folder\" />\n" +
                            "<div class=\"body-content-table-folder-text\">" + folders.ElementAt(foldersIndex).FolderName +
                            "</div></td>";

                            foldersIndex++;
                        }
                    }

                    // Add files to table
                    if(exitFolders)
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
                            string[] fileExtension = files.ElementAt(filesIndex).Filename.Split('.');

                            htmlOutput += "<td>\n<a href=\"../../Image/DisplayImage?filename=" + files.ElementAt(filesIndex).Filename + 
                            "\"><img src=\"../../Images/User/" + fileExtension[0] + "_thumb." + fileExtension[1] + 
                            "\" class=\"body-content-table-image\"/>\n" +                      
                            "<input type=\"checkbox\" class=\"body-content-table-checkbox\" name=\"selectedBoxes\" id=\"" +
                            files.ElementAt(filesIndex).FileID.ToString() + "_folder\" /></a>\n</td>";

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