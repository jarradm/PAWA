using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

using AwesomeMvcDemo.Models;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Areas.Test.Controllers
{
    public class MealErrorAjaxDropdownController : Controller
    {
        public ActionResult GetItems(int? v, int? parent)
        {
            throw new Exception("AjaxDropdown example error message");
        }
    }

    public class W1AjaxDropdownController : Controller
    {
        public ActionResult GetItems(int? v)
        {
            Thread.Sleep(1000);
            return Json(new[]
                {
                    new SelectableItem(1,"1"),
                    new SelectableItem(2,"2"),
                    new SelectableItem(3,"3"),
                });
        }
    }

    public class W2AjaxDropdownController : Controller
    {
        public ActionResult GetItems(int? v)
        {
            Thread.Sleep(2000);
            return Json(new[]
                {
                    new SelectableItem(10,"10"),
                    new SelectableItem(20,"20"),
                    new SelectableItem(30,"30"),
                });
        }
    }

    public class W3AjaxDropdownController : Controller
    {
        public ActionResult GetItems(int? v, int w1, int w2)
        {
            return Json(new []{new SelectableItem(w1+w2, (w1+w2).ToString(CultureInfo.InvariantCulture))});
        }
    }

    public class WCategoriesAjaxCheckboxListController : Controller
    {
        public ActionResult GetItems(int[] v, int w1, int w2)
        {
            v = v ?? new int[] { };
            return Json(Db.Categories.Select(o => new SelectableItem(o.Id, o.Name+w1+w2, v.Contains(o.Id))));// key, text, checked
        }
    }
}