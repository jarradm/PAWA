using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using AwesomeMvcDemo.ViewModels;

namespace AwesomeMvcDemo.Controllers
{
    public class AjaxRadioListDemoController : Controller
    {
        public ActionResult Index()
        {
            return View(new AjaxDropdownDemoInput
                {
                    ParentCategory = Db.Categories[0].Id, 
                    CategoryData = Db.Categories[0].Id,
                    Category = Db.Categories[0].Id
                });
        }
    }
}