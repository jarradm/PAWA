using System.Web.Mvc;

namespace AwesomeMvcDemo.Controllers
{
    public class PopupDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Meals()
        {
            return View();
        }

        public ActionResult PopupWithParameters(string parent, int p1, string a, string b)
        {
            ViewData["parent"] = parent;
            ViewData["p1"] = p1;
            ViewData["a"] = a;
            ViewData["b"] = b;

            return View();
        }
    }
}