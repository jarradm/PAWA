using System.Linq;
using System.Web.Mvc;

using AwesomeMvcDemo.Models;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class MealsAjaxCheckboxListController : Controller
    {
        public ActionResult GetItems(int[] v)
        {
            v = v ?? new int[] { };
            return Json(Db.Meals
                          .Select(o => new SelectableItem(o.Id, o.Name, v.Contains(o.Id))));
        }
    }
}