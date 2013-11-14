using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class MealOfManyController : Controller
    {
        public ActionResult GetItems(int[] v, int[] parent)
        {
            v = v ?? new int[] { };
            parent = parent ?? new int[] { };
            var meals = Db.Meals.Where(o => o.Category != null && (parent.Contains(o.Category.Id)));
            return Json(meals.Select(o => new SelectableItem(o.Id, o.Name, v.Contains(o.Id))));
        }
    }
}