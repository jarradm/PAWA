using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class SelectionTypeAjaxDropdown : Controller
    {
        public ActionResult GetItem(int? v)
        {
            var items = new List<SelectionType> { SelectionType.None, SelectionType.Single, SelectionType.Multiple };
            return Json(items.Select(o => new SelectableItem((int)o, o.ToString(), (int)o == v)));
        }
    }
}