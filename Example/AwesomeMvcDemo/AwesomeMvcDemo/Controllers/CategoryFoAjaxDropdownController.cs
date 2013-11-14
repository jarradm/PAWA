using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    // with first option
    public class CategoryFoAjaxDropdownController : Controller
    {
        public ActionResult GetItems(int? v, string foText)
        {
            var list = new List<SelectableItem> { new SelectableItem("", foText ?? "please select") };
            list.AddRange(Db.Categories.Select(o => new SelectableItem(o.Id, o.Name, v == o.Id)));
            return Json(list);
        }
    }
}