using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class CategoriesAjaxCheckboxListController : Controller
    {
        public ActionResult GetItems(int[] v)
        {
            v = v ?? new int[] { };
            return Json(Db.Categories.Select(o => new SelectableItem(o.Id, o.Name, v.Contains(o.Id))));// key, text, checked
        }
    }
    /*end*/
}