using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class GridMantainSelectionDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MealsGrid(GridParams g)
        {
            return Json(new GridModelBuilder<Meal>(Db.Meals.AsQueryable(), g).Build());
        }
    }
}