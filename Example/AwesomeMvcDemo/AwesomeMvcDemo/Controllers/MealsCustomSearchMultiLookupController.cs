using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class MealsCustomSearchMultiLookupController : Controller
    {
        //when CustomSearch(true) this action will be rendered instead of the default search
        public ActionResult SearchForm()
        {
            return View();
        }

        public ActionResult GetItems(int[] v)
        {
            return Json(Db.Meals.Where(o => v != null && v.Contains(o.Id))
                            .Select(f => new KeyContent(f.Id, f.Name)));
        }

        public ActionResult Search(string search, int[] selected, int[] categories, int page)
        {
            const int PageSize = 10;
            selected = selected ?? new int[] { };
            search = (search ?? "").ToLower().Trim();
            categories = categories ?? new int[] { };

            var items = Db.Meals.Where(o => o.Name.ToLower().Contains(search)
                                            && (!selected.Contains(o.Id))
                                            && (o.Category != null && categories.Contains(o.Category.Id) || categories.Count() == 0));

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