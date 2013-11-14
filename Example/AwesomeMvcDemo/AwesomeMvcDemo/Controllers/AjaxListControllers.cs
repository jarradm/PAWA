using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class MealsTableAjaxListController : Controller
    {
        //isTheadEmpty is sent only when .TableLayout(true)
        public ActionResult Search(int[] categories, string name, string orderby, int page, bool isTheadEmpty)
        {
            categories = categories ?? new int[] { };
            name = (name ?? string.Empty).ToLower().Trim();

            const int PageSize = 10;

            var list = Db.Meals.Where(o =>
                (!categories.Any() || o.Category != null && categories.Contains(o.Category.Id))
                && o.Name.ToLower().Contains(name)).OrderByDescending(o => o.Id);

            if (orderby == "Name") list = list.OrderBy(o => o.Name);
            if (orderby == "Category") list = list.OrderBy(o => o.Category.Name);
            var r = new AjaxListResult
                        {
                            Content = this.RenderView("ListItems/MealCrud", list.Skip((page - 1) * PageSize).Take(PageSize)),
                            More = list.Count() > page * PageSize
                        };
            if (isTheadEmpty) r.Thead = this.RenderView("ListItems/MealCrudThead");
            return Json(r);
        }
    }

    public class DinnersAjaxListController : Controller
    {
        public ActionResult Search(string search, int page, bool isTheadEmpty, int? pageSize)
        {
            pageSize = pageSize ?? 10;
            search = (search ?? "").ToLower().Trim();
            var list = Db.Dinners.Where(o => o.Name.ToLower().Contains(search))
                .OrderByDescending(o => o.Id);

            var r = new AjaxListResult
                        {
                            Content = this.RenderView("ListItems/Dinner", list.Skip((page - 1) * pageSize.Value).Take(pageSize.Value)),
                            More = list.Count() > page * pageSize
                        };
            if (isTheadEmpty) r.Thead = this.RenderView("ListItems/DinnerThead");
            return Json(r);
        }
    }
}