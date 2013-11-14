using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class MealCustomItemLookupController : Controller
    {
        public ActionResult GetItem(int? v)
        {
            var o = Db.Meals.SingleOrDefault(f => f.Id == v) ?? new Meal();

            return Json(new KeyContent(o.Id, o.Name));
        }

        public ActionResult Search(string search, int page)
        {
            var pageSize = 10;
            search = (search ?? "").ToLower().Trim();
            var list = Db.Meals.Where(f => f.Name.ToLower().Contains(search));
            return Json(new AjaxListResult
            {
                Content = this.RenderView("items", list.Skip((page - 1) * pageSize).Take(pageSize)),
                More = list.Count() > page * pageSize
            });
        }

        public ActionResult Details(int id)
        {
            return View(Db.Get<Meal>(id) ?? new Meal());
        }

    }

    public class MealTableLayoutLookupController : Controller
    {
        public ActionResult GetItem(int? v)
        {
            var o = Db.Meals.SingleOrDefault(f => f.Id == v) ?? new Meal();

            return Json(new KeyContent(o.Id, o.Name));
        }

        //when using TableLayout(true) we will get a isTheadEmpty bool variable
        //which will tell us wheter the table header is empty
        public ActionResult Search(string search, int page, bool isTheadEmpty)
        {
            const int PageSize = 5;
            search = (search ?? "").ToLower().Trim();
            var list = Db.Meals.Where(f => f.Name.ToLower().Contains(search));
            var result = new AjaxListResult
                             {
                                 Content = this.RenderView("ListItems/Meal", list.Skip((page - 1) * PageSize).Take(PageSize)),
                                 More = list.Count() > page * PageSize
                             };
            //setting the table header with rendered html
            if (isTheadEmpty) result.Thead = this.RenderView("ListItems/MealThead");

            return Json(result);
        }
    }

    public class ChefLookupController : Controller
    {
        public ActionResult GetItem(int? v)
        {
            var o = Db.Get<Chef>(v) ?? new Chef();

            return Json(new KeyContent(o.Id, o.FirstName + " " + o.LastName));
        }

        public ActionResult Search(string search, int page)
        {
            const int PageSize = 7;
            search = (search ?? "").ToLower().Trim();

            var list = Db.Chefs.Where(f => (f.FirstName + " " + f.LastName).ToLower().Contains(search));
            return Json(new AjaxListResult
            {
                Items = list.Skip((page - 1) * PageSize).Take(PageSize).Select(o => new KeyContent(o.Id, o.FirstName + " " + o.LastName)),
                More = list.Count() > page * PageSize
            });
        }
    }

    public class DinnerLookupController : DinnersAjaxListController
    {
        //used for custom search when .CustomSearch(true)
        public ActionResult SearchForm()
        {
            return View();
        }

        public ActionResult GetItem(int? v)
        {
            var o = v == null || v == 0 ? new Dinner() : Db.Get<Dinner>(v);

            return Json(new KeyContent(o.Id, o.Name));
        }
    }

    public class CategoryLookupController : Controller
    {
        public ActionResult GetItem(int? v)
        {
            var o = Db.Get<Category>(v) ?? new Category();

            return Json(new KeyContent(o.Id, o.Name));
        }

        public ActionResult Search(string search, int page)
        {
            var pageSize = 7;
            search = (search ?? "").ToLower().Trim();

            var list = Db.Categories.Where(f => f.Name.ToLower().Contains(search));
            return Json(new AjaxListResult
            {
                Items = list.Skip((page - 1) * pageSize).Take(pageSize).Select(o => new KeyContent(o.Id, o.Name)),
                More = list.Count() > page * pageSize
            });
        }
    }
}