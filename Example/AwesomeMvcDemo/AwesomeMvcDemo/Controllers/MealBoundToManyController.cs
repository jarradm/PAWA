using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class MealBoundToManyController : Controller
    {
        public ActionResult GetItems(int? v, int[] parent, string mealName)
        {
            parent = parent ?? new int[] { };
            
            var meals = Db.Meals.Where(o => 
                (parent.Contains(o.Category.Id))
                && o.Name.Contains(mealName));

            return Json(meals.Select(o => new SelectableItem(o.Id, o.Name, v == o.Id)));
        }
    }
    /*end*/
}