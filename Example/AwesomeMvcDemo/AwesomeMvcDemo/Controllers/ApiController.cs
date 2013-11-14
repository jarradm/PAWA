using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using AwesomeMvcDemo.Models;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class CategoriesApiController : ApiController
    {
        [HttpPost]
        public IEnumerable<SelectableItem> GetItems(VparentInput input)
        {
            return Db.Categories.Select(o => new SelectableItem(o.Id, o.Name, input.V == o.Id.ToString()));
        }
    }

    public class MealsApiController : ApiController
    {
        [HttpPost]
        public IEnumerable<SelectableItem> GetItems(VparentInput input)
        {
            return Db.Meals.Where(o => o.Category.Id.ToString() == input.Parent)
                .Select(o => new SelectableItem(o.Id, o.Name, input.V == o.Id.ToString()));
        }
    }

    public class MealsListApiController : ApiController
    {
        [HttpPost]
        public AjaxListResult GetItems(PageParentInput input)
        {
            const int PageSize = 5;
            input.Parent = (input.Parent ?? "").ToLower();

            var list = Db.Meals.Where(o => o.Name.ToLower().Contains(input.Parent));

            return new AjaxListResult
            {
                Items = list.Skip((input.Page - 1) * PageSize).Take(PageSize).Select(o => new KeyContent(o.Id, o.Name)),
                More = list.Count() > input.Page * PageSize // bool - show More button or not
            };
        }
    }

    public class ChefGridApiController : ApiController
    {
        [HttpPost]
        public GridModel<Chef> GetItems(GridParams g)
        {
            var list = Db.Chefs.AsQueryable();

            return new GridModelBuilder<Chef>(list, g)
            {
                // Key = "Id", // needed when using Entity Framework
                Map = o => new
                {
                    o.Id,
                    o.FirstName,
                    o.LastName,
                    CountryName = o.Country.Name,
                }
            }.Build();
        }
    }

    public class VparentInput
    {
        public string V { get; set; }

        public string Parent { get; set; }
    }

    public class PageParentInput
    {
        public int Page { get; set; }
        public string Parent { get; set; }
    }
}
