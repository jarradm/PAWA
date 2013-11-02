using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using PAWA.DAL;
using System.Security.Cryptography;

namespace PAWA.Classes
{
    public class Tools
    {
       public static Nullable<bool> uploaded { get; set; } //Used for confirmation on uploads
       public static Nullable<bool> tagAdded { get; set; } // ^
       
       public static Nullable<int> DDLChoice { get; set; } //Dropdown lists are fucking stupid
       public static int totalImageCount {get; set;} //counter for index adding
       private static List<int> selectedfile { get; set; } //list containing ids
       public static int UserID { get; set; }
        /*
           *  ImageResize(Image, Size)
           *  Take in image, create a new bitmap, bitmap size = newsize
           *  Render and clean image
           *  Apply image to bitmap
           *  
           *  Return the thumbnail
        */
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
            return newImage;
        }
        /*
         * checkExtension(string)
         * 
         * Checks the extension of the image  
         * and returns the correct format for saving
        */
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
        /*
           *  Rename(string, string)
           *  Take in original file name & new file name
           * 
           *  set tempName = newname + oldnames extension
           *  eg. tempname = thenewname + .jpg
           *      result   = thenewname.jpg
        */
        public string Rename(string original, string newName)
        {
            string tempName;
            tempName = newName + original.Substring(original.Length - 4);

            return tempName;
        }

        /*
         * SeperateTags(string)
         * Seperate the string via ','
         * 
         * Replace , with space
         * cut up string via spaces and 
         * store into array.
         * return array.
         */
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
        /*
         * checkIfTagExists(string[]) 
         * 
         * Will used the passed array to compare
         * against the DB, if the tag doesnt exist
         * it will create it. returning all of the
         * images tags IDs in a List<int>
        */
        public List<int> checkIfTagExists(string[] TagArr)
        {
            PAWAContext db = new PAWAContext();

            //All of the images tag's Ids in a list
            List<int> ImageTagsIDs = new List<int>();

            foreach (string s in TagArr)
            {
                //results == any rows in the db that match 's'
                var results = db.Tags.Where(t => t.TagName.Contains(s));
                //If tag does exist
                if (results != null && results.Count() >= 1)
                {
                    System.Diagnostics.Debug.WriteLine(s +"Is in DB ");
                    ImageTagsIDs.Add(getTagID(s));
                }
                //If tag doesnt exist
                else
                {
                    System.Diagnostics.Debug.WriteLine("Is not in DB\nAdding new tag '" + s + "'...");
                    createTag(s);
                    System.Diagnostics.Debug.WriteLine("Tag  '" + s + "' added sucessfully.");
                    ImageTagsIDs.Add(getTagID(s));
                }
            } 
            return ImageTagsIDs;    
        }

        public string convertTagsToString(List<int> TagIDs)
        {
            string temp = string.Join(",", TagIDs);
            return temp;
        }
        /*
         * CreateTag(String) -- Users
         * 
         * Used to insert tags into the DB
        */
        public void createTag(string name)
        {
            PAWAContext db = new PAWAContext();
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
       /*
        * getTagID(string)
        * 
        * Used to get the tags id via
        * passed tag name
       */
        public int getTagID(string tag)
        {
            PAWAContext db = new PAWAContext();

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
        /*
        * DeselectFile(int) 
        * removes a file from the list of files
        * set totalcount - 1
       */
        public void deselectFile(int id)
        {
            if (selectedfile.Contains(id))
            {
                selectedfile.Remove(id);
                totalImageCount -= 1;
            }
        }

        /*
         * SelectFile(int) 
         * adds a file from the list of files
         * set totalcount + 1
        */
        public List<int> selectFile(int id)
        {
            totalImageCount += 1;
            selectedfile[totalImageCount] = id;
            return selectedfile;
        }
        
        /*
         * DeleteImage(List<int>) 
         * Removes selected image(s) from the database
        */
        public void deleteImage(List<int> ids)
        {
            PAWAContext db = new PAWAContext();

            foreach(int fileId in ids)
            {
                var deleteSelectedImages =
                    from File in db.Files
                    where File.FileID == fileId
                    select File;
                
                db.Files.Remove(deleteSelectedImages.SingleOrDefault());  
            }
           

            db.SaveChanges(); 
           
            //Reset count for next selection
            totalImageCount = 0;
        }
        public IList<PAWA.Models.Folder> getFolders(int userID)
        {
            //open db connection
            PAWAContext db = new PAWAContext();
           
            //create new list for files,
            //will be used to generate DDL options
            IList<Models.Folder> list = new List<Models.Folder>(); 
            
            //Foreach folder in the database
            foreach (var f in db.Folders)
            {
                //if folder belongs to user
                if (f.UserID == userID)
                {
                    //add folder to List
                    list.Add(new Models.Folder { FolderID = f.FolderID, FolderName = f.FolderName });
                }
            }
            return list;
        }
        /*
         *  InsertImagetoDB(int,int,int,string,string,string,int)
         * 
         *  Uses all passed parimeters to create a new db 
         *  image object, then pushes it into the db and saves  
         */
        public void insertImageToDB(int Height,int Width, int FileSize, string FileName, string Tags, string Description, int FolderID )
        {
            PAWAContext db = new PAWAContext();
            Tools.UserID = 1;

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
                TypeID = 1,
                UserID = Tools.UserID,
                FolderID = FolderID
            };
            
            db.Files.Add(ImageFile);
            db.SaveChanges();
        }
        /*
         * PhotoValidation(HttpPostedFileBase) 
         * 
         * Confirms that the file uploaded is
         * not null and is a image of the required
         * type.
         */
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

        private string HexByteArrayToHexString(byte[] hexValues, string fileExtension)
        {
            System.Text.StringBuilder hexString = new System.Text.StringBuilder(hexValues.Length * 2);

            foreach(var hexByte in hexValues)
            {
                hexString.AppendFormat("{0:x2}", hexByte);
            }

            return hexString.ToString() + "." + fileExtension;
        }
       /* public int[] getTagIDs(string[] tags)
        {
            PAWAContext db = new PAWAContext();
            int[] tagIDS;
            
            List<Models.Tags> TagDB;
            var results = TagDB.Where(nc => nc.TagName.ToLower().StartsWith());

           
           

            return
        }*/

    }
}