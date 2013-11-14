using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using AwesomeMvcDemo.ViewModels;

namespace AwesomeMvcDemo.Controllers
{
    public class ListBindingController : Controller
    {
        public ActionResult Index()
        {
            return View(new ListBindingInput {Dinners = Db.Dinners.Take(3).Select(o => new DinnerInput
                                                           {
                                                               Id = o.Id,
                                                               Name = o.Name,
                                                               Date = o.Date,
                                                               Chef = o.Chef.Id,
                                                               Meals = o.Meals.Select(m => m.Id)
                                                           }).ToList()});
        }

        [HttpPost]
        public ActionResult Index(ListBindingInput input)
        {
            return View(input);
        }
    }

    public class ListBindingInput
    {
        public IList<DinnerInput> Dinners { get; set; } 
    }
}