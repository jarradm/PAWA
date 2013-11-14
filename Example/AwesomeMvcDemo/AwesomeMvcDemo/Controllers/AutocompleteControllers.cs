using System;
using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class MealChildAutocompleteController : Controller
    {
        public ActionResult GetItems(string v, int[] parent)
        {
            v = (v ?? "").ToLower().Trim();
            parent = parent ?? new int[] { };

            var items = Db.Meals.Where(o => o.Name.ToLower().Contains(v));
            if (parent.Count() != 0) items = items.Where(o => o.Category != null && parent.Contains(o.Category.Id));

            return Json(items.Take(10).Select(o => new KeyContent(o.Id, o.Name, false)));
        }
    }

    public class CategoryAutocompleteController : Controller
    {
        public ActionResult GetItems(string v)
        {
            v = (v ?? "").ToLower().Trim();
            return Json(Db.Categories.Where(o => o.Name.ToLower().Contains(v))
                .Select(o => new KeyContent(o.Id, o.Name, false)));
        }
    }
}