using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class ChildMealsAjaxCheckboxListController : Controller
    {
        public ActionResult GetItems(int[] v, int? parent)
        {
            v = v ?? new int[] { };
            return Json(Db.Meals.Where(o => o.Category != null && o.Category.Id == parent)
                .Select(o => new SelectableItem(o.Id, o.Name, v.Contains(o.Id))));
        }
    }
}