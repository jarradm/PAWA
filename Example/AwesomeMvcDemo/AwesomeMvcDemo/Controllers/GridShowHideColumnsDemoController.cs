using System.Web.Mvc;

namespace AwesomeMvcDemo.Controllers
{
    public class GridShowHideColumnsDemoController : Controller
    {
        public ActionResult Index()
        {
            return View(new GridHideColumnsDemoInput{ ShowFood = true, ShowLocation = true });
        }

        public ActionResult GridContent(GridHideColumnsDemoInput input)
        {
            return View(input);
        }
    }

    public class GridHideColumnsDemoInput
    {
        public bool ShowFood { get; set; }

        public bool ShowLocation { get; set; }

        public bool ShowDate { get; set; }
    }
}