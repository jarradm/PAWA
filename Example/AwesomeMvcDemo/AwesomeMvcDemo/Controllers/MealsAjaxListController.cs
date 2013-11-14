using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class MealsAjaxListController : Controller
    {
        public ActionResult Search(int page, string parent)
        {
            const int PageSize = 5;
            parent = (parent ?? "").ToLower();

            var list = Db.Meals.Where(o => o.Name.ToLower().Contains(parent));

            return Json(new AjaxListResult
                            {
                                Items = list.Skip((page - 1) * PageSize).Take(PageSize).Select(o => new KeyContent(o.Id, o.Name)),
                                More = list.Count() > page * PageSize // bool - show More button or not
                            });
        }
    }
    /*end*/
}