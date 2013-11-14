using System.Web.Mvc;

using AwesomeMvcDemo.ViewModels;

namespace AwesomeMvcDemo.Controllers
{
    public class UnobtrusiveController : Controller
    {
        public ActionResult Index()
        {
            return View(new UnobstrusiveInput());
        }

        [HttpPost]
        public ActionResult Index(UnobstrusiveInput input)
        {
            return View(input);
        }
    }
}