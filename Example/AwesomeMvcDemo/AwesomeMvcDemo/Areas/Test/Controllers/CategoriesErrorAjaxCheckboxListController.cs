using System;
using System.Linq;
using System.Web.Mvc;

using AwesomeMvcDemo.Models;

namespace AwesomeMvcDemo.Areas.Test.Controllers
{
    public class CategoriesErrorAjaxCheckboxListController : Controller
    {
        public ActionResult GetItems(int[] v)
        {
            throw new Exception("AjaxCheckboxList example error message");
        }
    }
}