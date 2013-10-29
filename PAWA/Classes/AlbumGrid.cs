using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAWA.Models;
using PAWA.DAL;

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
            
            var folders1 = new List<Folder>
            {
                new Folder { UserID = 1, InFolderID = null, 
                    CreateDateTime = DateTime.Parse("2013/08/28 13:21:50"), 
                    FolderName = "Australian Holiday" },

                new Folder { UserID = 1, InFolderID = 1, 
                    CreateDateTime = DateTime.Parse("2013/08/29 17:16:15"), 
                    FolderName = "Sydney" },

                new Folder { UserID = 1, InFolderID = 1, 
                    CreateDateTime = DateTime.Parse("2013/08/29 17:16:15"), 
                    FolderName = "Melbourne" },

                new Folder { UserID = 1, InFolderID = 1, 
                    CreateDateTime = DateTime.Parse("2013/08/29 17:16:15"), 
                    FolderName = "Perth" },

                new Folder { UserID = 1, InFolderID = 1, 
                    CreateDateTime = DateTime.Parse("2013/08/29 17:16:15"), 
                    FolderName = "Canberra" },

                new Folder { UserID = 1, InFolderID = 1, 
                    CreateDateTime = DateTime.Parse("2013/08/29 17:16:15"), 
                    FolderName = "Darwin" }
            };
             

            return folders1;
        }

        public IEnumerable<File> GetFiles()
        {
            var UserID = 1;

            var files = from f in dbContext.Files
                        where f.UserID == UserID
                        select f;

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

            return files;
        }

        /* 
         * Builds a table based on the amount of files and folders of the user.
         * 
         * Returns a string containing the html content to display on page.
        */
        public string CreateTable()
        {
            IEnumerable<Folder> folders = GetFolders();
            IEnumerable<File> files = GetFiles();
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