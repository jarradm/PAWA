using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class GridChooseColumnsDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        /*begin*/
        public ActionResult GetItems(GridParams g, string[] selectedColumns, bool? choosingColumns)
        {
            //when setting columns from here we don't get the grid defaults, so we have to specify Sortable, Groupable etc.
            var columns = new[]
                              {
                                  new Column { Name = "Id", Width = 70, Order = 1 },
                                  new Column { Name = "Person", Sortable = true, Groupable = true, GroupRemovable = true, Order = 2 },
                                  new Column { Name = "Food", Sortable = true, Groupable = true, GroupRemovable = true, Order = 3 },
                                  new Column { Name = "Location", Sortable = true, Groupable = true, GroupRemovable = true, Order = 4 },
                                  new Column { Name = "Date", Sortable = true, Groupable = true, GroupRemovable = true, Width = 100, Order = 5 },
                                  new Column { Name = "Price", Sortable = true, Groupable = true, GroupRemovable = true, Width = 100, Order = 6 },
                              };

            var baseColumns = new[] { "Id", "Person" };

            //first load
            if (g.Columns.Length == 0)
            {
                g.Columns = columns;
            }

            if (choosingColumns.HasValue && selectedColumns == null)
            {
                selectedColumns = new string[] { };
            }

            if (selectedColumns != null)
            {
                //make sure we always have Id and Person columns
                selectedColumns = selectedColumns.Union(baseColumns).ToArray();

                var currectColumns = g.Columns.ToList();

                //remove unselected columns
                currectColumns = currectColumns.Where(o => selectedColumns.Contains(o.Name)).ToList();

                //add missing columns
                var missingColumns = selectedColumns.Except(currectColumns.Select(o => o.Name)).ToArray();

                currectColumns.AddRange(columns.Where(o => missingColumns.Contains(o.Name)));

                g.Columns = currectColumns.ToArray();
            }

            var gridModel = new GridModelBuilder<Lunch>(Db.Lunches.AsQueryable(), g).Build();

            // used to populate the checkboxlist
            gridModel.Tag =
                new
                    {
                        columns = columns.Select(o => o.Name).Except(baseColumns).ToArray(),
                        selectedColumns = g.Columns.Select(o => o.Name).Except(baseColumns).ToArray()
                    };

            return Json(gridModel);
        }

        public ActionResult GetColumnsItems(string[] columns, string[] selectedColumns)
        {
            columns = columns ?? new string[] { };
            selectedColumns = selectedColumns ?? new string[] { };

            return Json(columns.Select(o => new SelectableItem(o, o, selectedColumns.Contains(o))));
        }/*end*/
    }
}