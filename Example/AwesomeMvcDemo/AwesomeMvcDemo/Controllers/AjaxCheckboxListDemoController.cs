using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using AwesomeMvcDemo.ViewModels;

namespace AwesomeMvcDemo.Controllers
{
    public class AjaxCheckboxListDemoController : Controller
    {
        public ActionResult Index()
        {
            return View(new AjaxCheckboxListDemoInput { CategoryData = Db.Categories[0].Id });
        }
    }
}