using System;
using System.Web.Mvc;

namespace AwesomeMvcDemo.Areas.Test.Controllers
{
    public class MealErrorAjaxRadioListController : Controller
    {
        public ActionResult GetItems(int? v, int? parent)
        {
            throw new Exception("AjaxRadioList example error message");
        }
    }
}