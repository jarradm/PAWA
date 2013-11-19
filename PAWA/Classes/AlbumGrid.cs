﻿using System;
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
    public class AlbumGrid : Controller
    {
        private IPAWAContext dbContext;

        public int TilesPerPage { get; set; }
        public int TilesPerRow { get; set; }

        public AlbumGrid(IPAWAContext dbc, int tilesPerPage = 20, int tilesPerRow = 5)
        {
            dbContext = dbc;
            TilesPerPage = tilesPerPage;
            TilesPerRow = tilesPerRow;
        }

        /*
         * Returns a collection of Folder objects of a single user,
         * based on current folder level
        */
        public IEnumerable<Folder> GetFolders(int? folderID)
        {
            var UserID = WebSecurity.CurrentUserId;

            var folders = from f in dbContext.Folders
                          where f.UserID == UserID && (f.InFolderID == folderID || (f.InFolderID == null && folderID == null))
                          select f;             

            return folders;
        }

        /*
         * Returns a collection of File objects of a single user,
         * based on the current folder level
        */
        public IEnumerable<File> GetFiles(int? folderID)
        {
            var UserID = WebSecurity.CurrentUserId;

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
            IEnumerable<Folder> folders = GetFolders(folderID);
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
                        // no more folders at current level
                        if (foldersIndex >= folders.Count())
                        {
                            exitFolders = true;
                        }

                        if(!exitFolders)
                        {
                            htmlOutput += "<td>\n<a href=\"./Album?folderID=" + folders.ElementAt(foldersIndex).FolderID + "\">" +
                            "<img src=\"../../Images/folder.png\" class=\"body-content-table-image\"/>\n" +
                            "<input type=\"checkbox\" class=\"body-content-table-checkbox\" id=\"" +
                            folders.ElementAt(foldersIndex).FolderID.ToString() + "_folder\" name=\"" +
                            folders.ElementAt(foldersIndex).FolderID.ToString() + "_folder\" />\n" +
                            "<div class=\"body-content-table-folder-text\">" + folders.ElementAt(foldersIndex).FolderName +
                            "</div></a></td>";

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
                            "<input type=\"checkbox\" class=\"body-content-table-checkbox\" name=\"" +
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

        public List<string> CreateTable1(int? folderID)
        {
            IEnumerable<Folder> folders = GetFolders(folderID);
            IEnumerable<File> files = GetFiles(folderID);
            string htmlOutput = "";
            List<string> htmlTables = new List<string>();
            int i=0, foldersIndex = 0, filesIndex = 0, count=0;
            bool exitFiles = false, exitFolders = false;

            while (!exitFiles)
            {
                htmlOutput = "<table class=\"body-content-table\" id=\"table-" + htmlTables.Count() + "\">" +
                    "<tr><td colspan=\"" + TilesPerRow + "\"><div id=\"table-header-page-count\">Page " + (htmlTables.Count() + 1) + "</div>\n";

                while(count < (TilesPerPage/TilesPerRow) && !exitFiles)
                {                    
                    htmlOutput += "<tr>\n";

                    for (i = 0; i < TilesPerRow; i++)
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
                                htmlOutput += "<td>\n<a href=\"./Album?folderID=" + folders.ElementAt(foldersIndex).FolderID + "\">" +
                                "<img src=\"../../Images/folder.png\" class=\"body-content-table-image\"/>\n" +
                                "<input type=\"checkbox\" class=\"body-content-table-checkbox\" id=\"" +
                            folders.ElementAt(foldersIndex).FolderID.ToString() + "_folder\" name=\"" +
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
                            // one row of data. Doesn't fill if at start of row, don't want full row of fakes.
                            if (exitFiles && i > 0)
                            {
                                htmlOutput += "<td>\n<span class=\"body-content-table-fakeimage\"/></span>\n"; ;
                            }
                            else if (exitFiles && i == 0)
                            {
                                break;
                            }
                            else
                            {
                                string[] fileExtension = files.ElementAt(filesIndex).Filename.Split('.');

                                htmlOutput += "<td>\n<a href=\"../../Image/DisplayImage?filename=" + files.ElementAt(filesIndex).Filename +
                                "\"><img src=\"../../Images/User/" + fileExtension[0] + "_thumb." + fileExtension[1] +
                                "\" class=\"body-content-table-image\"/>\n" +
                                "<input type=\"checkbox\" class=\"body-content-table-checkbox\" name=\"" +
                                files.ElementAt(filesIndex).FileID.ToString() + "\" id=\"" +
                                files.ElementAt(filesIndex).FileID.ToString() + "\" /></a>\n</td>";

                                filesIndex++;
                            }
                        }
                    }

                    count++;
                    htmlOutput += "</tr>\n";
                }

                htmlOutput += "</table>\n";
                if (!(exitFiles && i == 0))
                {
                    htmlTables.Add(htmlOutput);
                }
                count = 0;
            }

            return htmlTables;
        }
    }
}