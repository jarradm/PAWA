using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class MealsApiDemoAjaxListController : Controller
    {
        public ActionResult Search(int page, string meal, int? pageSize)
        {
            pageSize = pageSize ?? 5;
            meal = (meal ?? "").ToLower();

            var list = Db.Meals.Where(o => o.Name.ToLower().Contains(meal));

            return Json(new AjaxListResult
                {
                    Items = list.Skip((page - 1) * pageSize.Value).Take(pageSize.Value).Select(o => new KeyContent(o.Id, o.Name)),
                    More = list.Count() > page * pageSize.Value // bool - show More button or not
                });
        }
    }
    /*end*/
}