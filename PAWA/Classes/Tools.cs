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
         */
        public string seperateTags(string s)
        {
            string temp = s;
            if (temp.Contains(','))
            {
               temp = temp.Replace(',', ' ');
            }
            return temp;
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

    }
}