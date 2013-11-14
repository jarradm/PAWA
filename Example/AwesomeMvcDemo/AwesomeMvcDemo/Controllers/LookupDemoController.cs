using System.Web.Mvc;
using AwesomeMvcDemo.ViewModels;

namespace AwesomeMvcDemo.Controllers
{
    public class LookupDemoController : Controller
    {
        public ActionResult Index()
        {
            return View(new LookupDemoCfgInput
                            {
                                HighlightChange = true,
                                Width = 750,
                                Height = 400
                            });
        }

        [HttpPost]
        public ActionResult IndexContent(LookupDemoCfgInput input)
        {
            return View(input);
        }

        public ActionResult CustomSearch()
        {
            return View();
        }


        public ActionResult Misc()
        {
            return View(new LookupDemoInput());
        }
    }

    public class LookupDemoCfgInput
    {
        public int? Meal { get; set; }

        public bool ClearButton { get; set; }

        public bool HighlightChange { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public bool Fullscreen { get; set; }
    }
}