using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using Facebook;

namespace PAWA.Classes
{
    public class SocialMediaTools
    {
        /*
         * Note: This class file Requires the Facebook SDK package.
         *       'install-package facebook'
        */

        ///<summary> 
        /// Posts a image to facebook into the default API album  
        /// Using the currently open client and imagename for file
        /// Note: Token was previously attached to client
        ///</summary>
        public void PostToFacebook(string ImageName, FacebookClient fbClient)
        {
            //need to find a way to generate one of these badboys for each user
            //accessToken = "574337319304836|b2C4ux1eLIwslioarBVTS6A0Ruo";
            string Extension = checkExtension(ImageName);
            var imgstream = File.OpenRead(System.Web.HttpContext.Current.Server.MapPath("~/Images/User/" + ImageName.Split('.')[0] + Extension));
           
            //May have an error with /me/, need to get other people to test on their accounts
            dynamic res = fbClient.Post("/me/photos", new
            {
                message = "Uploaded from my PAWA Album.", //Use this to change the images title
                file = new FacebookMediaStream
                {
                    ContentType = ("image/" + Extension.Replace(".","")), //Remove the . from the extension
                    FileName = "TestFileName"
                }.SetValue(imgstream)
            });
        }
        ///<summary> 
        /// Checks the extension of the image  
        /// and returns the extension in a string
        ///</summary>
        public String checkExtension(string file)
        {
            if (file.Contains(".jpg") || file.Contains(".jpeg"))
            {
                return ".jpg";
            }
            else if (file.Contains(".png"))
            {
                return ".png";
            }
            else if (file.Contains(".bmp"))
            {
                return ".bmp";
            }
            return null; //Should never reach this
        }
       
    }
}