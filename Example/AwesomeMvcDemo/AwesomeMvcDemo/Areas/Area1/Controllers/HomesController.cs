using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Areas.Area1.Controllers
{
    public class HomesController : Controller
    {
        //
        // GET: /Area1/Home/

        public ActionResult Index()
        {
            return View();
        }
    }

    public class BineAjaxDropdownController : Controller
    {
        public ActionResult GetItems(int? v)
        {
            return Json(Db.Categories.Select(o => new SelectableItem(o.Id, o.Name, v == o.Id)));
        }
    }
}
