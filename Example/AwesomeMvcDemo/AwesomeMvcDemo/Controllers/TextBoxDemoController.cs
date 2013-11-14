using System.Web.Mvc;

namespace AwesomeMvcDemo.Controllers
{
    public class TextBoxDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }

    public class TextBoxDemoInput
    {
        public string Name { get; set; }
    }
}