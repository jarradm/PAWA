using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class ApiMealAjaxDropdownController : Controller
    {
        public ActionResult GetItems(int? v, string text = "a")
        {
            var items = Db.Meals.Where(o => o.Name.ToLower().Contains(text.ToLower()))
                          .Select(o => new SelectableItem(o.Id, o.Name, v == o.Id));

            return Json(items);
        }
    }/*end*/
}