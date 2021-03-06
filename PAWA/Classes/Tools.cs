﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using PAWA.DAL;
using System.Security.Cryptography;
using WebMatrix.WebData;
using PAWA.Models;
using System.Data;

namespace PAWA.Classes
{
    public class Tools
    {
        PAWAContext db = new PAWAContext();
        public static Nullable<bool> uploaded { get; set; } //Used for confirmation on uploads
        public static Nullable<bool> tagAdded { get; set; } // ^
       
        public static Nullable<int> DDLChoice { get; set; } //Dropdown lists are fucking stupid
        public static int totalImageCount {get; set;} //counter for index adding
        private static List<int> selectedfile { get; set; } //list containing ids
        public static int UserID { get; set; }

        public IEnumerable<File> GetFilesFromFolder(int? folderID, int? userId)
        {
            //db = new PAWAContext();
            IEnumerable<File> files;
            if (userId != null)
            {
                var UserID = userId;
                files = from f in db.Files
                        where f.UserID == UserID && (f.FolderID == folderID || (f.FolderID == null && folderID == null))
                        select f;
            }
            else
            {
                files = new HashSet<File> { };
            }
            return files;
        }

        /// <summary>
           ///  Take in image, create a new bitmap, bitmap size = newsize
           ///  Render and clean image
           ///  Apply image to bitmap
           ///  
           ///  Return the thumbnail
        /// </summary>
        public Image ImageResize(Image imgFile, Size newSize)
        {
            
           
            var newImage = new Bitmap(newSize.Width, newSize.Height); //create a new blank image, set H & W
            using (var newGraphics = Graphics.FromImage(newImage))
            {
                newGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                newGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                newGraphics.DrawImage(imgFile, new Rectangle(0, 0, newSize.Width, newSize.Height));
            }

            imgFile.Dispose();

            return newImage;
        }
        ///<summary> 
         /// Checks the extension of the image  
         /// and returns the correct format for saving
        ///</summary>
        public System.Drawing.Imaging.ImageFormat checkExtension(string file)
        {
            //Create variable for storing image type
            System.Drawing.Imaging.ImageFormat type;
           
            if (file.Contains(".jpg"))
            {
                type = System.Drawing.Imaging.ImageFormat.Jpeg;
                return type;
            }
            else if (file.Contains(".png"))
            {
                type = System.Drawing.Imaging.ImageFormat.Png;
                return type;
            }
            else if (file.Contains(".bmp"))
            {
                type = System.Drawing.Imaging.ImageFormat.Bmp;
                return type;
            }
            return null;
        }
        ///<summary>
         /// Seperate the string via ','
         /// 
         /// Replace , with space
         /// cut up string via spaces and 
         /// store into array.
         /// return array.
        ///</summary>
        public string[] seperateTags(string s)
        {
            string[] TagArr;
            string temp = s;

            if (temp.Contains(','))
            {
               temp = temp.Replace(',', ' ');
            }
            TagArr = temp.Split(' ');

           return TagArr;
        }
        ///<summary>
         /// Will used the passed array to compare
         /// against the DB, if the tag doesnt exist
         /// it will create it. returning all of the
         /// images tags IDs in a List(int)
        ///</summary>
        public List<int> checkIfTagExists(string[] TagArr)
        {
            //db = new PAWAContext();

            //All of the images tag's Ids in a list
            List<int> ImageTagsIDs = new List<int>();

            foreach (string s in TagArr)
            {
                //Convert tag to lowercase for safer use
                string tagLower = s.ToLower();

                //results == any rows in the db that match 's'
                var results = db.Tags.Where(t => t.TagName.Contains(tagLower));

                //If tag does exist
                if (results != null && results.Count() >= 1)
                {
                    System.Diagnostics.Debug.WriteLine(tagLower +"Is in DB ");
                    ImageTagsIDs.Add(getTagID(tagLower));
                    TagUsedCountIncrease(tagLower);
                }
                //If tag doesnt exist
                else
                {
                    System.Diagnostics.Debug.WriteLine("Is not in DB\nAdding new tag '" + tagLower + "'...");
                    createTag(tagLower, "user");
                    System.Diagnostics.Debug.WriteLine("Tag  '" + tagLower + "' added sucessfully.");
                    ImageTagsIDs.Add(getTagID(tagLower));
                }
            } 
            return ImageTagsIDs;    
        }
        public PAWA.Models.Tags getTag(int id)
        {
            //db = new PAWAContext();
            Models.Tags theTag;

            var tag = 
                from x in db.Tags
                where x.TagsID == id
                select x;

            theTag = tag.FirstOrDefault();

            return theTag;
        }
        ///<summary>
         /// Increase the selected tags usedcount
         /// in the database by 1 everytime this
         /// method is called
        ///</summary>
        public void TagUsedCountIncrease(string tagName)
        {
            //db = new PAWAContext();
            
            var tag =
                from x in db.Tags
                where x.TagName == tagName
                select x;

          

            foreach (var selectedTag in tag)
            {
                selectedTag.UseCount ++; 
            }

            db.SaveChanges();
        }
        ///<summary>
         /// Combines all the tagIDs from a List
         /// into a string for AlbumView Display
        ///</summary>
        public string convertTagsToString(List<int> TagIDs)
        {
            string temp = string.Join(",", TagIDs);
            return temp;
        }
        ///<summary>
         /// Used to insert tags into the DB
        ///</summary>
        public void createTag(string name, string type)
        {
            
            if (type == "user")
            {
                //db = new PAWAContext();
                var newTag = new PAWA.Models.Tags
                {

                    FirstDateTime = System.DateTime.Now,
                    Status = Models.Status.Active,
                    TagName = name,
                    UseCount = 1,
                    UserSuggest = Models.UserSuggest.User
                };
                db.Tags.Add(newTag);
                db.SaveChanges();
            }
            else if (type == "admin")
            {
                PAWAContext db = new PAWAContext();
                var newTag = new PAWA.Models.Tags
                {
                    FirstDateTime = System.DateTime.Now,
                    Status = Models.Status.Active,
                    TagName = name,
                    UseCount = 0,
                    UserSuggest = Models.UserSuggest.Suggested
                };
                db.Tags.Add(newTag);
                db.SaveChanges();
            }
        }
        ///<summary>
        /// Used to get the tags id via
        /// passed tag name
        ///</summary>
        public int getTagID(string tag)
        {
            //db = new PAWAContext();

            var test =
                from x in db.Tags
                where x.TagName == tag
                select x.TagsID;
            
            foreach (var TagsID in test)
            {
                return TagsID;
            }

            return 0;
        }
        ///<summary>
        /// removes a file from the list of files
        /// set totalcount - 1
        ///</summary>
        public void deselectFile(int id)
        {
            if (selectedfile.Contains(id))
            {
                selectedfile.Remove(id);
                totalImageCount -= 1;
            }
        }

        ///<summary>
         /// SelectFile(int) 
         /// adds a file from the list of files
         /// set totalcount + 1
        ///</summary>
        public List<int> selectFile(int id)
        {
            totalImageCount += 1;
            selectedfile[totalImageCount] = id;
            return selectedfile;
        }
        ///<summary>
        /// Returns all of the users owned
        /// folders in a List(folders)   
        ///</summary>
        public IList<PAWA.Models.Folder> getFolders(int userID)
        {
            //open db connection
            //db = new PAWAContext();
           
            //create new list for files,
            //will be used to generate DDL options
            IList<Models.Folder> list = new List<Models.Folder>();
           
            //Add Root directory
            list.Add(new Models.Folder {FolderID = -1, FolderName = "Root"});

            //Foreach folder in the database
            foreach (var f in db.Folders)
            {
                //if folder belongs to user
                if (f.UserID == userID)
                {
                    //add folder to List
                    list.Add(new Models.Folder { FolderID = f.FolderID, FolderName = f.FolderName, InFolderID = f.InFolderID });
                }
                
            }
            return list;
        }
        public IList<PAWA.Models.File> getFiles(int userID)
        {
            //db = new PAWAContext();

            IList<Models.File> list = new List<Models.File>();

            foreach (var f in db.Files)
            {
                list.Add(new Models.File { FileID = f.FileID, Filename = f.Filename });
            }
            return list;
        }
        ///<summary>
         ///  Uses all passed parimeters to create a new db 
         ///  image object, then pushes it into the db and saves  
        ///</summary>
        public void insertImageToDB(int Height,int Width, int FileSize, string FileName, string Tags, string Description, int? FolderID)
        {
            //db = new PAWAContext();
            Tools.UserID = WebSecurity.CurrentUserId;

            if (FolderID == -1)
            {
                FolderID = null;
            }

            // get filename extension
            var ext = ("." + FileName.Split('.')[1]);

            var tid = from t in db.Types
                      where t.Extension == ext
                      select t;
          
            var ImageFile = new PAWA.Models.File
            {
                UploadedDateTime = System.DateTime.Now,
                SizeHeight = Height,
                SizeWidth = Width,
                SizeMB = FileSize,
                Filename = FileName,
                Tags = Tags,
                Description = Description,

                //Required
                TypeID = tid.SingleOrDefault().TypeID,
                UserID = Tools.UserID,
                FolderID = FolderID
            };
            
            db.Files.Add(ImageFile);
            db.SaveChanges();
        }
        ///<summary>
         /// Confirms that the file uploaded is
         /// not null and is a image of the required
         /// type.
        ///</summary>
        public Boolean PhotoValidation(HttpPostedFileBase image)
        {
            if (image != null)
            {
                if (image.FileName.Contains(".jpg") || image.FileName.Contains(".png") || image.FileName.Contains(".bmp"))
                {
                    return true;
                }
            }
            return false;
        }
     /// <summary>
     /// Gets the Users object via passed ID
     /// </summary>
        public PAWA.Models.User getUserByID(int id)
        {
          //db = new PAWAContext();
          PAWA.Models.User theUser;

            var USER =
             from x in  db.Users
             where x.UserID == id
             select x;

            theUser = USER.FirstOrDefault();
            
            return theUser;
        }
        /// <summary>
        /// Gets all users
        /// </summary>
        public IEnumerable<PAWA.Models.User> GetUsers()
        {
            PAWAContext db = new PAWAContext();
            var users = from u in db.Users
                        select u;
            return users;
        }
        public string CreateFilename(int userid, string filename)
        {
            string stringToHash = DateTime.UtcNow.ToString() + "_" + userid.ToString() + "_" + filename;
            byte[] byteToHash = new byte[stringToHash.Length];
            byte[] hashValueBytes;
            string[] fileExtension = filename.Split('.');

            SHA256 sha = SHA256Managed.Create();
            
            System.Buffer.BlockCopy(stringToHash.ToCharArray(), 0, byteToHash, 0, stringToHash.Length);

            hashValueBytes = sha.ComputeHash(byteToHash);

            return HexByteArrayToHexString(hashValueBytes, fileExtension[fileExtension.Length-1]);
        }

        /// <summary>
        /// Converts a hexadecimal byte array into a filename string representing the
        /// hexadecimal bytes.
        /// </summary>
        /// <param name="hexValues">Byte array, representing hexadecimal values.</param>
        /// <param name="fileExtension">File extension of the filename.</param>
        /// <returns>Filename string</returns>
        private string HexByteArrayToHexString(byte[] hexValues, string fileExtension)
        {
            System.Text.StringBuilder hexString = new System.Text.StringBuilder(hexValues.Length * 2);

            foreach(var hexByte in hexValues)
            {
                hexString.AppendFormat("{0:x2}", hexByte);
            }

            return hexString.ToString() + "." + fileExtension;
        }

        /// <summary>
        /// Gets the 100 most used tags from the database.
        /// </summary>
        /// <returns>List of tags</returns>
        public static List<Tags> GetTop100Tags(IPAWAContext dbContext)
        {
            var tags = dbContext.Tags.OrderByDescending(t => t.UseCount);
            int count = 0;
            List<Tags> top100Tags = new List<Tags>();

            foreach (var tag in tags)
            {
                // exit loop once we have 100 tags
                if (count == 100)
                {
                    break;
                }

                top100Tags.Add(tag);
                count++;
            }

            return top100Tags;
        }

        public static string CreateTagCloudOverlayContents(List<Tags> tags)
        {
            string tagcloud = "";
            int count = 0;

            foreach (var tag in tags)
            {
                if (count % 5 == 0 && count != 0)
                {
                    tagcloud += "<br>";
                }

                tagcloud += "<span class=\"tagcloud-overlay-item\"><input type=\"button\" name=\"" + tag.TagName.ToString() +
                    "\" value=\"+\" onclick=\"AddTagToTextBox(this)\">" + tag.TagName.ToString() + "</span>";
                count++;
            }

            return tagcloud;
        }
        
        ///<summary>
        /// Returns the specific Folder, given the
        /// Folder ID and the User ID.
        ///</summary>
        /// <param name="userID">ID of the user to witch the folder pertains.</param>
        /// <param name="folderID">ID of the folder that is being fetched.</param>
        /// <returns>Returns the requested folder. </returns>
        public PAWA.Models.Folder getFolder(int userID, int? folderID)
        {
            //open db connection
            //db = new PAWAContext();
            /// WARNING !!!
            ///  IF db has Zero index, change conditional from "<=" to "<"
            if (userID <= 0) { userID = 1; } // Assumption handle: User id is always greater then zero
            if (folderID <= 0) { folderID = null; } // No folder less then zero (considered null)
            var folders = from f in db.Folders where (f.FolderID == folderID || (f.FolderID == null && folderID == null)) && f.UserID == userID select f;
            Folder returnFolder;
            if (folders.Count() > 0) { returnFolder = folders.FirstOrDefault(); } else { returnFolder = new Folder(); }

            return returnFolder;
        }
        /// <summary>
        /// The overloaded Get folder method. 
        /// </summary>
        /// <param name="userID">ID of the user to witch the folder pertains.</param>
        /// <param name="folderID">ID of the folder that is being fetched.</param>
        /// <returns>Returns the requested folder. </returns>
        public PAWA.Models.Folder getFolder(int userID, string folderID)
        {
            // test for folder, being null or true
            int convertedFolderID;
            if (folderID == "" || !Int32.TryParse(folderID, out convertedFolderID)) { convertedFolderID = -1; } // else { convertedFolderID = Convert.ToInt32(folderID); }
            Folder returnFolder = getFolder(userID, convertedFolderID);

            return returnFolder;
        }
        /// <summary>
        /// Returns 1 if the subfolder is within the directory tree of the parent folder. Returns 0 if root folder . If the subfolder is in a nonconventional loop(root folder is missing), the return is -1.
        /// </summary>
        /// <param name="subfolder">Folder that is presumed to be a child of the parent folder</param>
        /// <param name="parentFolder">folder that is persumed to contain the sub folder</param>
        /// <returns></returns>
        public int isSubfolder(Folder subfolder, Folder parentFolder)
        {
            int _RootID = 0;
            if (subfolder.FolderID == _RootID) { return _RootID; }
            int returnValue = -1;
            if (subfolder != null && parentFolder != null && parentFolder.UserID == subfolder.UserID)
            {
                //Folder subsParent? = getFolder(subfolder.UserID, subfolder.InFolderID);
                Folder testSubFolder = getFolder(subfolder.UserID, subfolder.FolderID);
                Folder testParentFolder = getFolder(parentFolder.UserID, parentFolder.FolderID);
                bool hasNotReachedRoot = true;
                //int inIndex = Convert.ToInt32(destinationFolder);
                if (findInfinateParentLoop(subfolder) == -1)
                {
                    while ((hasNotReachedRoot = (testSubFolder.FolderID != _RootID)) && (testSubFolder.FolderID != testParentFolder.FolderID))
                    {
                        testSubFolder = getFolder(testSubFolder.UserID, testSubFolder.InFolderID);
                    }
                    if (hasNotReachedRoot) { returnValue = 1; } else { returnValue = 0; }
                }
                else { returnValue = -1; }
            }
            return returnValue;
        }
        public int findInfinateParentLoop(Folder testFolderIn)
        {
            int _RootID = 0;
            bool hasNotReachedRoot = true;
            int i = -1;

            if (testFolderIn != null)
            {
                Folder testFolder = getFolder(testFolderIn.UserID, testFolderIn.FolderID);
                //int inIndex = Convert.ToInt32(destinationFolder);
                IList<int> folderIDChain = new List<int> { };
                while ((hasNotReachedRoot = (testFolder.FolderID != _RootID)) && i <= 0)
                {
                    //check every list item in folderIDChain to see if the folder id has already been seen
                    int? c = folderIDChain.Count;
                    bool noLoopDetected = true;
                    for (i = (int)c; i > 1 && (noLoopDetected = folderIDChain.ElementAt(i - 1) != testFolder.FolderID); i--) { } 
                    if (noLoopDetected == false) { return folderIDChain.ElementAt((int)c - 1); }
                    folderIDChain.Add(testFolder.FolderID);
                    testFolder = getFolder(testFolder.UserID, testFolder.InFolderID);
                }
            }
            return -1;
        }
        public bool changeFolderName(int userID,int folderID,string newFolderName)
        {
            bool returnValue = true;
            if (newFolderName.Count() > 0 && folderID > 0)
            {
                Folder folderToEdit = getFolder(userID, folderID);
                //bool isFail = isSubfolder(destinationFolder, folderToMove) == 0/*Is not a subfolder*/;
                if (folderToEdit.FolderID != 0)
                {
                    folderToEdit.FolderName = newFolderName;
                    db.Entry<Folder>(folderToEdit).State = EntityState.Modified;
                    try { db.SaveChanges(); }
                    catch (Exception e) { System.Diagnostics.Debug.WriteLine("Error : " + e); }
                }
                else {returnValue = false;}
                // Method will return the true false 
            }
            return returnValue;
        }
        public bool moveFolder(int userID, string folderToMoveID, int? destinationFolderID) 
        {
            return moveFolder(userID, folderToMoveID, destinationFolderID.ToString());
        }
        public bool moveFolder(int userID, string folderToMoveID, string destinationFolderID)
        {
            bool returnValue = false;
            Folder folderToMove = getFolder(userID, folderToMoveID);
            Folder destinationFolder = getFolder(userID, destinationFolderID);
            if (destinationFolder.FolderID == 0) // If putting it in root folder
            {
                folderToMove.InFolderID = null;
            }
            else // Check that it is not going inside itself
            {
                bool notSubFolder = isSubfolder(destinationFolder, folderToMove) == 0/*Is not a subfolder*/;
                if (notSubFolder)
                {
                    folderToMove.InFolderID = destinationFolder.FolderID;
                }
                else { return (!notSubFolder); }
                // Method will return the true false 
            }
            {
                db.Entry<Folder>(folderToMove).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e) { System.Diagnostics.Debug.WriteLine("Error : " + e); }
                returnValue = true;
            }
            return returnValue;
        }
    }
}