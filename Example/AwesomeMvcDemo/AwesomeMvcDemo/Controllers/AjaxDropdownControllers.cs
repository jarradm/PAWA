using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    //AjaxDropdown and AjaxRadioList can easily use the same controllers

    public class ChefAjaxRadioListController : Controller
    {
        public ActionResult GetItems(int? v)
        {
            return Json(Db.Chefs.Select(o => new SelectableItem(o.Id, o.FirstName + "" + o.LastName, v == o.Id)));
        }
    }
}