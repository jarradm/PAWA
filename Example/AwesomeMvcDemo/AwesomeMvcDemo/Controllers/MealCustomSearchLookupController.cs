using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class MealCustomSearchLookupController : Controller
    {
        public ActionResult SearchForm()
        {
            return View();
        }

        public ActionResult GetItem(int? v)
        {
            var o = Db.Meals.SingleOrDefault(f => f.Id == v) ?? new Meal();

            return Json(new KeyContent(o.Id, o.Name));
        }

        public ActionResult Search(string search, int[] categories, int page)
        {
            var pageSize = 10;
            search = (search ?? "").ToLower().Trim();
            categories = categories ?? new int[] { };

            var list = Db.Meals.Where(f => f.Name.ToLower().Contains(search) //give list of meals where name contains search
             && (!categories.Any() || f.Category != null && categories.Contains(f.Category.Id)));// if categories specified, filter by them
            return Json(new AjaxListResult
                            {
                                Items = list.Skip((page - 1) * pageSize).Take(pageSize).Select(o => new KeyContent(o.Id, o.Name)),
                                More = list.Count() > page * pageSize
                            });
        }
    }
    /*end*/
}