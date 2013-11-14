using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class MealsTableLayoutAjaxListController : Controller
    {
        public ActionResult Search(int page, bool isTheadEmpty)
        {
            const int PageSize = 5;
            var result = new AjaxListResult
                             {
                                 Content = this.RenderView("CustomItems", Db.Meals.Skip((page - 1) * PageSize).Take(PageSize)),
                                 More = Db.Meals.Count > page*PageSize
                             };
            if (isTheadEmpty) result.Thead = this.RenderView("TableHeader");

            return Json(result);
        }
    }
    /*end*/
}