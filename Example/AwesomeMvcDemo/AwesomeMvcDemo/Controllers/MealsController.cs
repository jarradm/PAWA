using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using AwesomeMvcDemo.ViewModels;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class MealsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Db.Delete<Meal>(id);
            return Json(new { Id = id });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MealInput input)
        {
            if (!ModelState.IsValid) return View(input);

                var meal = Db.Insert(new Meal {Name = input.Name, Category = Db.Categories.Single(o => o.Id == input.Category), Description = input.Description});
                return Json(new { Content = this.RenderView("ListItems/MealCrud", new[] { meal }) });
        }

        public ActionResult Edit(int id)
        {
            var m = Db.Meals.SingleOrDefault(o => o.Id == id);
            if (m == null)
                throw new AwesomeDemoException("this item doesn't exist anymore");

            var vm = new MealInput { Id = m.Id, Name = m.Name, Category = m.Category.Id, Description = m.Description };

            return View("create", vm);
        }

        [HttpPost]
        public ActionResult Edit(MealInput input)
        {
            var m = Db.Get<Meal>(input.Id);

            m.Name = input.Name;
            m.Description = input.Description;
            m.Category = Db.Get<Category>(input.Category);

            return Json(new { Id = m.Id, Content = this.RenderView("ListItems/MealCrud", new[] { m }) });
        }
    }
}