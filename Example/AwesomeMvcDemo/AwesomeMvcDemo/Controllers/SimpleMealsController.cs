using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using AwesomeMvcDemo.ViewModels;

namespace AwesomeMvcDemo.Controllers
{
/*begin*/
    public class SimpleMealsController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MealInput input)
        {
            if (!ModelState.IsValid) return View(input);

            Db.Insert(new Meal
                            {
                                Name = input.Name, 
                                Category = Db.Categories.Single(o => o.Id == input.Category), 
                                Description = input.Description
                            });

            return Json(new { });
        }
    }
/*end*/
}