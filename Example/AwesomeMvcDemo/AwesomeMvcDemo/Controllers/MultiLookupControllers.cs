using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;
namespace AwesomeMvcDemo.Controllers
{
    public class MealsTableLayoutMultiLookupController : Controller
    {
        public ActionResult GetItems(int[] v)
        {
            v = v ?? new int[] {};
            return Json(Db.Meals.Where(f => v.Contains(f.Id)).Select( o => new KeyContent(o.Id, o.Name)));
        }

        //when using TableLayout(true) we will get a isTheadEmpty bool variable
        //which will tell us whether the table header is empty
        public ActionResult Search(string search, int page, bool isTheadEmpty)
        {
            const int PageSize = 5;
            search = (search ?? "").ToLower().Trim();
            var list = Db.Meals.Where(f => f.Name.ToLower().Contains(search));

            //viewdata will be passed to RenderView
            //in meal.ascx there's a check for ViewData["multilookup"]
            // if it's not null the move button for the multilookup will be rendered
            ViewData["multilookup"] = true;

            var result = new AjaxListResult
            {
                Content = this.RenderView("ListItems/Meal", list.Skip((page - 1) * PageSize).Take(PageSize)),
                More = list.Count() > page * PageSize
            };

            //setting the table header with rendered html
            if (isTheadEmpty) result.Thead = this.RenderView("ListItems/MealThead");

            return Json(result);
        }

        public ActionResult Selected(int[] selected, bool isTheadEmpty)
        {
            ViewData["multilookup"] = true;
            var result = new AjaxListResult
                        {
                            Content = this.RenderView("ListItems/Meal",Db.Meals.Where(o => selected != null && selected.Contains(o.Id)))
                        };
            if (isTheadEmpty) result.Thead = this.RenderView("ListItems/MealThead");
            return Json(result);
        }
    }

    public class MealsCustomItemMultiLookupController : Controller
    {
        public ActionResult GetItems(int[] v)
        {
            return Json(Db.Meals.Where(o => v != null && v.Contains(o.Id))
                            .Select(f => new KeyContent(f.Id, f.Name)));
        }

        public ActionResult Search(string search, int[] selected, int page)
        {
            const int PageSize = 10;
            selected = selected ?? new int[] { };
            search = (search ?? "").ToLower().Trim();

            var items = Db.Meals.Where(o => o.Name.ToLower().Contains(search)
                && (!selected.Contains(o.Id)));
            
            //instead of setting the Items property we set the Content with rendered html
            return Json(new AjaxListResult
            {
                Content = this.RenderView("items", items.Skip((page - 1) * PageSize).Take(PageSize)),
                More = items.Count() > page * PageSize
            });
        }

        public ActionResult Selected(int[] selected)
        {
            return Json(new AjaxListResult
                            {
                                Content = this.RenderView("items", Db.Meals.Where(o => selected != null && selected.Contains(o.Id)))
                            });
        }

        //used by the details button, in items view
        public ActionResult Details(int id)
        {
            return View(Db.Get<Meal>(id));
        }
    }

    public class CategoriesMultiLookupController : Controller
    {
        public ActionResult GetItems(int[] v)
        {
            return Json(Db.Categories.Where(o => v != null && v.Contains(o.Id))
                            .Select(f => new KeyContent(f.Id, f.Name)));
        }

        public ActionResult Search(string search, int[] selected)
        {
            return Json(new AjaxListResult
            {
                Items = Db.Categories.Where(o => o.Name.Contains(search) && (selected == null || !selected.Contains(o.Id)))
                    .Select(o => new KeyContent(o.Id, o.Name))
            });
        }

        public ActionResult Selected(int[] selected)
        {
            return Json(
                new AjaxListResult
                    {
                        Items = Db.Categories.Where(o => selected != null && selected.Contains(o.Id))
                            .Select(o => new KeyContent(o.Id, o.Name))
                    });

        }
    }
}