using System.Web.Mvc;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class SortAjaxDropdownController : Controller
    {
        public ActionResult GetItems(Sort v)
        {
            var options = new[]
                              {
                                  new SelectableItem(Sort.None, "None", v == Sort.None),
                                  new SelectableItem(Sort.Asc, "Asc", v== Sort.Asc),
                                  new SelectableItem(Sort.Desc, "Desc", v== Sort.Desc)
                              };
            return Json(options);
        }
    }
}