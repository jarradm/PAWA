using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class MealAutocompleteController : Controller
    {
        public ActionResult GetItems(string v)// v is the entered text
        {
            v = (v ?? "").ToLower().Trim();

            var items = Db.Meals.Where(o => o.Name.ToLower().Contains(v));

            return Json(items.Take(10).Select(o => new KeyContent(o.Id, o.Name)));
        }
    }/*end*/
}