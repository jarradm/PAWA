using System.Web.Mvc;

using AwesomeMvcDemo.ViewModels;

namespace AwesomeMvcDemo.Controllers
{
    public class CrudInLookupController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LookupCrudInput input)
        {
            return View(input);
        }
    }
}