using System;
using System.Web.Mvc;

namespace AwesomeMvcDemo.Areas.Test.Controllers
{
    public class MealErrorLookupController : Controller
    {
        public ActionResult GetItem(int? v)
        {
            throw new Exception("Lookup example error message");
        }

        public ActionResult Search(string search, int page)
        {
            throw new Exception("Lookup example error message");
        }
    }
}