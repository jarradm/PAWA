using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class CascadingGridDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /*begin*/
        public ActionResult CategoriesGrid(GridParams g)
        {
            return Json(new GridModelBuilder<Category>(Db.Categories.AsQueryable(), g).Build());
        }

        public ActionResult MealsGrid(GridParams g, int[] categories)
        {
            categories = categories ?? new int[]{};

            return Json(new GridModelBuilder<Meal>(Db.Meals.Where(o => categories.Contains(o.Category.Id)).AsQueryable(), g).Build());
        }/*end*/
    }
}