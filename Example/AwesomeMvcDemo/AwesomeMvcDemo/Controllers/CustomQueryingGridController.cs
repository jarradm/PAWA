using System;
using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class CustomQueryingGridController : Controller
    {
        public ActionResult GetItems(GridParams g)
        {
            const int PageSize = 10;
            var items = Db.Lunches.AsQueryable();

            if (g.SortNames != null)
            {
                IOrderedQueryable<Lunch> orderedItems = null;

                // doing this for demo purposes
                // one might use something like Dynamic Linq or generate a sql string etc.
                for (int i = 0; i < g.SortNames.Length; i++)
                {
                    var column = g.SortNames[i];
                    var direction = g.SortDirections[i];

                    if (i == 0)
                    {
                        if (column == "Person")
                            orderedItems = direction == "asc"
                                               ? items.OrderBy(o => o.Person)
                                               : items.OrderByDescending(o => o.Person);
                        else if (column == "Food")
                            orderedItems = direction == "asc"
                                               ? items.OrderBy(o => o.Food)
                                               : items.OrderByDescending(o => o.Food);
                    }
                    else
                    {
                        if (column == "Person")
                            orderedItems = direction == "asc"
                                        ? orderedItems.ThenBy(o => o.Person)
                                        : orderedItems.ThenByDescending(o => o.Person);
                        else if (column == "Food")
                            orderedItems = direction == "asc"
                                        ? orderedItems.ThenBy(o => o.Food)
                                        : orderedItems.ThenByDescending(o => o.Food);
                    }
                }
                items = orderedItems;
            }

            var totalPages = (int)Math.Ceiling((float)items.Count() / PageSize);
            var page = items.Skip((g.Page - 1) * PageSize).Take(PageSize);

            return Json(new GridModelBuilder<Lunch>(page.AsQueryable(), g)
                {
                    PageCount = totalPages
                }.Build());
        }
    }
    /*end*/
}