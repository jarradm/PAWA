using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AwesomeMvcDemo.Controllers
{
    public class PopupFormDemoController : Controller
    {
        public ActionResult Index()
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

        [HttpPost]
        public ActionResult PopupWithParameters()
        {
            return Json(new { });
        }

        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(TestInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            return Json(new { });
        }
    }

    public class TestInput
    {
        public int? Id { get; set; }

        [Required]
        public int? Name { get; set; }
    }

}