using System.Linq;
using System.Web.Mvc;

using AwesomeMvcDemo.Models;
using AwesomeMvcDemo.ViewModels;

namespace AwesomeMvcDemo.Controllers
{
    public class AttributesDemoController : Controller
    {
        public ActionResult Index()
        {
            return View(new AttributesDemoInput(){ParentCategory = Db.Categories.First().Id});
        }

        [HttpPost]
        public ActionResult Index(AttributesDemoInput input)
        {
            return View(input);
        }
    }
}