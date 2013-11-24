using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAWA.Classes;
using PAWA.DAL;
using PAWA.Models;

namespace MvcApplication1.Tests.Classes
{
    [TestClass]
    public class DisplayImageTests
    {
        [TestMethod]
        public void DisplayImageTest()
        {
            var testDb = new TestPAWAContext
            {
                Tags =
                {
                    new Tags { TagsID = 1, Status = Status.Active, FirstDateTime = DateTime.Now, TagName = "sydney", UseCount = 1, UserSuggest = UserSuggest.User },
                    new Tags { TagsID = 2, Status = Status.Active, FirstDateTime = DateTime.Now, TagName = "brisbane", UseCount = 1, UserSuggest = UserSuggest.User },
                    new Tags { TagsID = 3, Status = Status.Active, FirstDateTime = DateTime.Now, TagName = "hobart", UseCount = 1, UserSuggest = UserSuggest.User },
                    new Tags { TagsID = 4, Status = Status.Active, FirstDateTime = DateTime.Now, TagName = "perth", UseCount = 1, UserSuggest = UserSuggest.User }
                }
            };

            string input1 = "1,2,3";
            string result1 = DisplayImage.GetTags(testDb, input1);
            string expectedResult1 = "sydney, brisbane, hobart";

            Assert.AreEqual(expectedResult1, result1);
        }
    }
}
