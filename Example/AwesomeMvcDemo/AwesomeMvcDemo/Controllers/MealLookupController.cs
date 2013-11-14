using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class MealLookupController : Controller
    {
        public ActionResult GetItem(int? v)
        {
            var o = Db.Meals.SingleOrDefault(f => f.Id == v) ?? new Meal();

            return Json(new KeyContent(o.Id, o.Name));
        }

        public ActionResult Search(string search, int page)
        {
            var pageSize = 7;
            search = (search ?? "").ToLower().Trim();
            
            var list = Db.Meals.Where(o => o.Name.ToLower().Contains(search));

            return Json(new AjaxListResult
                            {
                                Items = list.Skip((page - 1) * pageSize).Take(pageSize).Select(o => new KeyContent(o.Id, o.Name)),
                                More = list.Count() > page * pageSize
                            });
        }
    }
    /*end*/
}