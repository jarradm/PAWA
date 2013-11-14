using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class LunchCustomItemAjaxListController : Controller
    {
        public ActionResult Search(int page)
        {
            const int PageSize = 5;
            return Json(new AjaxListResult
                            {
                                Content = this.RenderView("ListItems/LunchCustomItem", Db.Lunches.Skip((page - 1) * PageSize).Take(PageSize).ToList()),
                                More = false
                            });
        }
    }
} 