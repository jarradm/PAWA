using System;
using System.Web.Mvc;

namespace AwesomeMvcDemo.Areas.Test.Controllers
{
    public class MealErrorAutocompleteController : Controller
    {
        public ActionResult GetItems(string v, int[] parent)
        {
            throw new Exception("Autocomplete example error message");
        }
    }
}