using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class MealsMultiLookupController : Controller
    {
        public ActionResult GetItems(int[] v)
        {
            return Json(Db.Meals.Where(o => v != null && v.Contains(o.Id))
                            .Select(meal => new KeyContent(meal.Id, meal.Name)));
        }

        public ActionResult Search(string search, int[] selected, int page)
        {
            const int PageSize = 10;
            selected = selected ?? new int[] { };
            search = (search ?? "").ToLower().Trim();

            var items = Db.Meals.Where(o => o.Name.ToLower().Contains(search) && (!selected.Contains(o.Id)));

            return Json(new AjaxListResult
                            {
                                Items = items.Skip((page - 1) * PageSize).Take(PageSize).Select(o => new KeyContent(o.Id, o.Name)),
                                More = items.Count() > page * PageSize
                            });
        }

        public ActionResult Selected(int[] selected)
        {
            return Json(new AjaxListResult
                            {
                                Items = Db.Meals.Where(o => selected != null && selected.Contains(o.Id))
                                    .Select(o => new KeyContent(o.Id, o.Name))
                            });
        }
    }
    /*end*/
}