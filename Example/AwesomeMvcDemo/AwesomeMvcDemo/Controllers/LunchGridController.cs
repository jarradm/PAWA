using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class LunchGridController : Controller
    {
        public ActionResult GetItems(GridParams g, string person, string food)
        {
            food = (food ?? "").ToLower();
            person = (person ?? "").ToLower();

            var list = Db.Lunches
                .Where(o => o.Food.ToLower().Contains(food) && o.Person.ToLower().Contains(person))
                .AsQueryable();

            return Json(new GridModelBuilder<Lunch>(list, g)
                {
                    // Key = "Id", // needed when using Entity Framework
                    Map = o => new
                    {
                        o.Id,
                        o.Person,
                        o.Food,
                        o.Location,
                        o.Price,
                        o.Date,
                        CountryName = o.Country.Name,
                        ChefName = o.Chef.FirstName + " " + o.Chef.LastName
                    }
                }.Build());
        }
    }/*end*/
}