using System.Collections.Generic;
using System.Web.Mvc;

namespace AwesomeMvcDemo.Controllers
{
    public class MultiLookupDemoController : Controller
    {
        public ActionResult Index()
        {
            return View(new MultiLookupDemoCfgInput
            {
                HighlightChange = true,
                Width = 750,
                Height = 465
            });
        }

        [HttpPost]
        public ActionResult IndexContent(MultiLookupDemoCfgInput input)
        {
            return View(input);
        }

        public ActionResult CustomSearch()
        {
            return View();
        }

        public ActionResult Misc()
        {
            return View();
        }
    }

    public class MultiLookupDemoCfgInput
    {
        public IEnumerable<int> Meals { get; set; }

        public bool ClearButton { get; set; }

        public bool HighlightChange { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public bool Fullscreen { get; set; }
            
        public bool DragAndDrop { get; set; }
    }
}