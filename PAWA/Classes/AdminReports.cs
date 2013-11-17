using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAWA.DAL;
using PAWA.Models;

namespace PAWA.Classes
{
    public class AdminReports
    {
        IPAWAContext dbContext;

        public AdminReports(IPAWAContext dbc)
        {
            dbContext = dbc;
        }

        public IEnumerable<Tags> GetTags()
        {
            var tags = from t in dbContext.Tags
                       orderby t.UseCount descending
                       select t;

            return tags;
        }

        /*
         *  Creates a table. Each row has nColumns of columns in it.
         */
        private string CreateTable(int nColumns, string[] columnHeaders, List<List<string>> rows, string tableId = "", string headerClass = "")
        {
            string table = "<table id=\"" + tableId + "\">\n    <tr>";
            int countRows = 0;

            // Add column headers
            foreach (var columnData in columnHeaders)
            {
                table += "\n        <td class=\"" + headerClass + "\">" + columnData + "</td>";
            }

            table += "\n    </tr>";

            // Add rows
            foreach (var row in rows)
            {
                table += "\n    <tr>";

                foreach (var columnData in row)
                {
                    table += "\n        <td";

                    if (countRows % 2 != 0)
                    {
                        table += " id=\"row-background-color\"";
                    }
                    
                    table += ">" + columnData + "</td>";

                }
                
                table += "\n    </tr>";
                countRows++;
            }

            table += "\n</table>";

            return table;
        }

        public string CreateTableForMostUsedTag(string tableId = "", string headerClass = "")
        {
            string[] columnHeaders = { "Rank", "Tag ID", "Tag Name", "Count" };
            List<List<string>> rows = new List<List<string>>();
            List<string> columns;
            int index = 1;

            var tags = GetTags();

            foreach (var tag in tags)
            {
                columns = new List<string>();
                columns.Add((index++).ToString());
                columns.Add(tag.TagsID.ToString());
                columns.Add(tag.TagName);
                columns.Add(tag.UseCount.ToString());
                rows.Add(columns);
            }

            return CreateTable(4, columnHeaders, rows, tableId, headerClass); 
        }

        public string CreateTableForMostUsedTagPerDay(string tableId = "", string headerClass = "")
        {
            string[] columnHeaders = { "Rank", "Tag ID", "Tag Name", "Count Per Day", "Date Created" };
            List<List<string>> rows = new List<List<string>>();
            List<string> columns;
            int index = 1;

            var tags = GetTags();

            foreach (var tag in tags)
            {
                // tag created on same day as report is day 1 not day 0
                double nDays = (double)(DateTime.Now.Date - tag.FirstDateTime.Date).Days + 1.0;
                double countPerDay = (double)tag.UseCount / nDays;
                countPerDay = Math.Round(countPerDay, 2);

                columns = new List<string>();
                columns.Add((index++).ToString());
                columns.Add(tag.TagsID.ToString());
                columns.Add(tag.TagName);
                columns.Add(countPerDay.ToString());
                columns.Add(tag.FirstDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                rows.Add(columns);
            }

            return CreateTable(5, columnHeaders, rows, tableId, headerClass); 
        }

        private string CreateTableForFileUsage(FileType ft, string[] columnHeaders, string tableId = "", string headerClass = "")
        {
            string[] status = { "Active", "Inactive", "Frozen" };
            List<List<string>> rows = new List<List<string>>();
            List<string> columns;
            double percentageOfUploads;


            int totalFiles = dbContext.Files.Count();

            var fileType = from t in dbContext.Types
                           where t.FileType == ft
                           select t;

            var fileTypeID = from t in fileType
                              select t.TypeID;

            var files = from f in dbContext.Files
                        where fileTypeID.Contains(f.TypeID)
                        select f;

            int totalImages = files.Count();

            foreach (var type in fileTypeID)
            {
                var filesWithExt = from f in files
                                   where f.TypeID == type
                                   select f;

                columns = new List<string>();

                var getType = fileType.Where(t => t.TypeID == type).SingleOrDefault();

                // file extension
                columns.Add(getType.Extension.ToString());
                int totalFilesWithExt = filesWithExt.Count();
                columns.Add(totalFilesWithExt.ToString());

                // percentage of uploads of file type with respect to total uploads
                // check for divide by zero
                if (totalFiles != 0)
                {
                    percentageOfUploads = (double)totalFilesWithExt / (double)totalFiles * 100.0;
                    percentageOfUploads = Math.Round(percentageOfUploads, 3, MidpointRounding.ToEven);
                }
                else
                {
                    percentageOfUploads = 0;
                }
                columns.Add(percentageOfUploads.ToString());

                // percentage of uploads of file type with respect to total file category
                // check for divide by zero
                if (totalImages != 0)
                {
                    percentageOfUploads = (double)totalFilesWithExt / (double)totalImages * 100.0;
                    percentageOfUploads = Math.Round(percentageOfUploads, 3, MidpointRounding.ToEven);
                }
                else
                {
                    percentageOfUploads = 0;
                }

                columns.Add(percentageOfUploads.ToString());

                columns.Add(status[(int)getType.Status]);

                rows.Add(columns);
            }

            return CreateTable(5, columnHeaders, rows, tableId, headerClass);
        }

        public string CreateTableForImageUsage(string tableId = "", string headerClass = "")
        {
            string[] columnHeaders = { "File Type", "Number Of Files", "% Of Uploads", "% Of Images", "Status" };

            return CreateTableForFileUsage(FileType.Image, columnHeaders, tableId, headerClass);
        }

        public string CreateTableForVideoUsage(string tableId = "", string headerClass = "")
        {
            string[] columnHeaders = { "File Type", "Number Of Files", "% Of Uploads", "% Of Videos", "Status" };

            return CreateTableForFileUsage(FileType.Video, columnHeaders, tableId, headerClass);
        }

        public string CreateTableForDailyUsage(string tableId = "", string headerClass = "")
        {
            string[] columnHeaders = { "Activity Type", "Date", "Increases", "Losses", "Total Movement" };
            List<List<string>> rows = new List<List<string>>();
            List<string> columns;
            int added, lost;

            var dailyStats = from d in dbContext.DailyStatistics
                             orderby d.Date ascending
                             select d;

            foreach (var stat in dailyStats)
            {
                columns = new List<string>();
                columns.Add("users");
                columns.Add(stat.Date.ToString("yyyy-MM-dd"));
                added = (int)((stat.UsersAddedCount == null) ? 0 : stat.UsersAddedCount);
                columns.Add(added.ToString());
                lost = (int)((stat.UsersLostCount == null) ? 0 : stat.UsersLostCount);
                columns.Add(lost.ToString());
                columns.Add((added - lost).ToString());
                rows.Add(columns);
                columns = new List<string>();

                columns.Add("images");
                columns.Add(stat.Date.ToString("yyyy-MM-dd"));
                added = (int)((stat.ImagesAddedCount == null) ? 0 : stat.ImagesAddedCount);
                columns.Add(added.ToString());
                lost = (int)((stat.ImagesLostCount == null) ? 0 : stat.ImagesLostCount);
                columns.Add(lost.ToString());
                columns.Add((added - lost).ToString());
                rows.Add(columns);
                columns = new List<string>();

                columns.Add("videos");
                columns.Add(stat.Date.ToString("yyyy-MM-dd"));
                added = (int)((stat.VideosAddedCount == null) ? 0 : stat.VideosAddedCount);
                columns.Add(added.ToString());
                lost = (int)((stat.VideosLostCount == null) ? 0 : stat.VideosLostCount);
                columns.Add(lost.ToString());
                columns.Add((added - lost).ToString());
                rows.Add(columns);
            }

            return CreateTable(5, columnHeaders, rows, tableId, headerClass);
        }

        private string CreateApplicationFileReport(FileType ft, string leftColumnClass = "", string rightColumnClass = "")
        {
            string report;
            int totalUploaded = 0;
            int averageSize = 0;
            int averagePerFolder = 0;
            int averagePerUser = 0;
            int mostImagesInOneUserAccount = 0;
            int totalFolders;

            var filesID = from i in dbContext.Types
                          where i.FileType == ft
                          select i.TypeID;

            var files = from f in dbContext.Files
                        where filesID.Contains(f.TypeID)
                        select f;

            totalUploaded = files.Count();

            totalFolders = dbContext.Folders.Count();

            // check for divide by zero
            if (totalFolders != 0)
            {
                averagePerFolder = totalUploaded / totalFolders;
            }
            else
            {
                averagePerFolder = 0;
            }

            // check for divide by zero
            if (totalUploaded != 0)
            {
                averageSize = files.Sum(i => i.SizeMB) / totalUploaded;
            }
            else
            {
                averageSize = 0;
            }

            var users = from u in dbContext.Users
                        select u.UserID;

            foreach(var id in users)
            {
                int count = files.Where(i => i.UserID == id).Count();

                if(mostImagesInOneUserAccount < count)
                {
                    mostImagesInOneUserAccount = count;
                }
            }

            var usersCount = users.Distinct().Count();

            // check for divide by zero
            if (usersCount != 0)
            {
                averagePerUser = files.Count() / users.Distinct().Count();
            }
            else
            {
                averagePerUser = 0;
            }

            report = "<span class=\"" + leftColumnClass + "\" id=\"row-background-color\">Total Uploaded</span><span class=\"" + rightColumnClass + "\" id=\"row-background-color\">" +
                totalUploaded.ToString() + "</span>";
            report += "<br><span class=\"" + leftColumnClass + "\">Average Size(KB)</span><span class=\"" + rightColumnClass + "\">" +
                averageSize.ToString() + "</span>";
            report += "<br><span class=\"" + leftColumnClass + "\" id=\"row-background-color\">Average Per Folder</span><span class=\"" + rightColumnClass + "\" id=\"row-background-color\">" +
                averagePerFolder.ToString() + "</span>";
            report += "<br><span class=\"" + leftColumnClass + "\" >Average Per User</span><span class=\"" + rightColumnClass + "\">" +
                averagePerUser.ToString() + "</span>";
            report += "<br><span class=\"" + leftColumnClass + "\" id=\"row-background-color\">Most Images In One Account</span><span class=\"" + rightColumnClass + "\" id=\"row-background-color\">" +
                mostImagesInOneUserAccount.ToString() + "</span>";

            return report;
        }

        public string CreateApplicationImageUsageReport(string leftColumnClass = "", string rightColumnClass = "")
        {
            return CreateApplicationFileReport(FileType.Image, leftColumnClass, rightColumnClass);
        }

        public string CreateApplicationVideoUsageReport(string leftColumnClass = "", string rightColumnClass = "")
        {
            return CreateApplicationFileReport(FileType.Video, leftColumnClass, rightColumnClass); 
        }

        public string CreateApplicationOtherUsageReport(string leftColumnClass="", string rightColumnClass="")
        {
            string report;
            int mostMBUsedInOneAccount = 0;
            int count;

            report = "<span class=\"" + leftColumnClass + "\" id=\"row-background-color\">Total Uploads</span><span class=\"" + rightColumnClass + "\" id=\"row-background-color\">" +
                dbContext.Files.Count() + "</span>";
            report += "<br><span class=\"" + leftColumnClass + "\">Average Folders Per User</span><span class=\"" + rightColumnClass + "\">" + 
                dbContext.Folders.Count() / dbContext.Users.Count() + "</span>";

            var users = dbContext.Users.Select(s => s.UserID);

            foreach (var user in users)
            {
                var c = from f in dbContext.Files
                        where f.UserID == user
                        select f.SizeMB;

                // check if any results returned
                if (c.Count() != 0)
                {
                    count = c.Sum();
                }
                else
                {
                    count = 0;
                }

                if (mostMBUsedInOneAccount < count)
                {
                    mostMBUsedInOneAccount = count;
                }
            }
            report += "<br><span class=\"" + leftColumnClass + "\" id=\"row-background-color\">Most MB Used In One Account</span><span class=\"" + rightColumnClass + "\" id=\"row-background-color\">" +
                Math.Round(((double)mostMBUsedInOneAccount / 1000.0), 2) + "</span>";

            return report;
        }

        public string GetCurrentDateTime()
        {
            return "Report Generated: " + DateTime.Now.ToString("HH:mm:ss yyyy-MM-dd");
        }
    }
}