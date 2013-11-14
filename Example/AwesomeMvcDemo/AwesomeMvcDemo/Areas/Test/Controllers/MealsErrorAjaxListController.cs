using System;
using System.Web.Mvc;

namespace AwesomeMvcDemo.Areas.Test.Controllers
{
    public class MealsErrorAjaxListController : Controller
    {
        public ActionResult Search(string parent, int page)
        {
            throw new Exception("AjaxList example error message");
        }
    }
}