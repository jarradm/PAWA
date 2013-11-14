using System.Linq;
using System.Web;
using System.Web.Mvc;

using AwesomeMvcDemo.Models;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class FooAutocompleteController : Controller
    {
        public ActionResult GetItems(string v)
        {
            v = (v ?? "").ToLower().Trim();
            return Json(Db.Foos.Where(o => o.Name.ToLower().Contains(v))
                .Select(o => new KeyContent(o.Name, o.Name, false)));
        }
    }

    public class FooLookupController : Controller
    {
        [ValidateInput(false)]
        public ActionResult GetItem(string v)
        {
            var o = Db.Foos.SingleOrDefault(f => f.Name == v) ?? new Foo();

            return Json(new KeyContent(o.Name, o.Name));
        }

        public ActionResult Search(string search, int page)
        {
            search = (search ?? "").ToLower().Trim();
            var list = Db.Foos.Where(f => f.Name.ToLower().Contains(search));
            return Json(new AjaxListResult
            {
                Items = list.Skip((page - 1) * 7).Take(7).Select(o => new KeyContent(o.Name, o.Name)),
                More = list.Count() > page * 7
            });
        }
    }

    public class FoosRadioAjaxRadioListController : Controller
    {
        [ValidateInput(false)]
        public ActionResult GetItems(string v)
        {
        //    v = HttpUtility.HtmlDecode(v);
            return Json(Db.Foos.Select(o => new SelectableItem(o.Name, o.Name, v == o.Name)));
        }
    }

    public class FoosAjaxCheckboxListController : Controller
    {
        [ValidateInput(false)]
        public ActionResult GetItems(string[] v)
        {
            v = v ?? new string[] { };
            return Json(Db.Foos.Select(o => new SelectableItem(o.Name, o.Name, v.Contains(o.Name))));
        }
    }

    public class FoosMultiLookupController : Controller
    {
        [ValidateInput(false)]
        public ActionResult GetItems(string[] v)
        {
            return Json(Db.Foos.Where(o => v != null && v.Contains(o.Name.ToString()))
                          .Select(o => new KeyContent(o.Name, o.Name)));
        }

        public ActionResult Search(string search, string[] selected, int page)
        {
            const int PageSize = 10;
            selected = selected ?? new string[] { };
            search = (search ?? "").ToLower().Trim();

            var items = Db.Foos.Where(o => o.Name.ToLower().Contains(search) && (!selected.Contains(o.Name.ToString())));

            return Json(new AjaxListResult
                {
                    Items = items.Skip((page - 1) * PageSize).Take(PageSize).Select(o => new KeyContent(o.Name, o.Name)),
                    More = items.Count() > page * PageSize
                });
        }

        public ActionResult Selected(string[] selected)
        {
            return Json(new AjaxListResult
                {
                    Items = Db.Foos.Where(o => selected != null && selected.Contains(o.Name.ToString()))
                              .Select(o => new KeyContent(o.Name, o.Name))
                });
        }
    }
}