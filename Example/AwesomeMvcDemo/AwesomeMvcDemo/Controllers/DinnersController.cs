using System;
using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using AwesomeMvcDemo.ViewModels;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class DinnersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Db.Delete<Dinner>(id);
            return Json(new { Id = id });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DinnerInput input)
        {
            if (!ModelState.IsValid) return View(input);

            var dinner = Db.Insert(new Dinner
                                       {
                                           Name = input.Name,
                                           Date = input.Date.Value,
                                           Chef = Db.Get<Chef>(input.Chef),
                                           Meals = Db.Meals.Where(o => input.Meals.Contains(o.Id))
                                       });

            return Json(new { Content = this.RenderView("ListItems/Dinner", new[] { dinner }) });
        }

        public ActionResult Edit(int id)
        {
            var m = Db.Dinners.SingleOrDefault(o => o.Id == id);
            if (m == null)
                throw new AwesomeDemoException("this item doesn't exist anymore");

            var vm = new DinnerInput { Id = m.Id, Name = m.Name, Chef = m.Chef.Id, Date = m.Date, Meals = m.Meals.Select(o => o.Id) };

            return View("create", vm);
        }

        [HttpPost]
        public ActionResult Edit(DinnerInput input)
        {
            if (!ModelState.IsValid) return View("create", input);
            var o = Db.Get<Dinner>(input.Id);

            o.Name = input.Name;
            o.Date = input.Date.Value;
            o.Chef = Db.Get<Chef>(input.Chef);
            o.Meals = Db.Meals.Where(m => input.Meals.Contains(m.Id));  
            Db.Update(o);

            return Json(new { Id = o.Id, Content = this.RenderView("ListItems/Dinner", new[] { o }) });
        }
    }
}