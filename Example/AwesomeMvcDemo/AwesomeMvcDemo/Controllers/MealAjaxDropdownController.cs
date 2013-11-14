using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class MealAjaxDropdownController : Controller
    {
        public ActionResult GetItems(int? v, int? parent)
        {
            return Json(Db.Meals.Where(o => o.Category != null && o.Category.Id == parent)
                            .Select(o => new SelectableItem(o.Id, o.Name, v == o.Id)));// key, text, selected
        }
    }/*end*/
}