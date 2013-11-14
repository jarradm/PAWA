using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class MealsCustomItemAjaxListController : Controller
    {
        public ActionResult Search(int page)
        {
            const int PageSize = 5;
            return Json(new AjaxListResult
                            {
                                Content = this.RenderView("CustomItem", Db.Meals.Skip((page - 1) * PageSize).Take(PageSize).ToList()),
                                More = Db.Meals.Count > (page * PageSize)
                            });
        }
    }
    /*end*/
}