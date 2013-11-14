using System.IO;
using System.Web.Mvc;
using AwesomeMvcDemo.ViewModels;

namespace AwesomeMvcDemo.Controllers
{
    public class FormDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string word)
        {
            TempData["word"] = word;
            return RedirectToAction("index");
        }

        public ActionResult AskName()
        {
            return View();
        }

/*begin*/
        [HttpPost]
        public ActionResult AskName(FormDemoInput input)
        {
            if (!ModelState.IsValid) return View(input);
            
            return Json(new { Name = input.FName + " " + input.LName });
        }
/*end*/
        public ActionResult FillForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FillForm(SayInput input)
        {
            return Content("You said " + input.SaySomething);
        }
    }
}