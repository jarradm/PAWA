using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using AwesomeMvcDemo.ViewModels;

namespace AwesomeMvcDemo.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryInput input)
        {
            if (!ModelState.IsValid)
                return View(input);
            Db.Insert(new Category{Name = input.Name});
            return Json(new {});
        }
    }
}