using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class GridSpreadsheetDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /*begin*/
        public ActionResult GridGetItems(GridParams g)
        {
            return Json(new GridModelBuilder<Spreadsheet>(Db.Spreadsheets.OrderByDescending(o => o.Id).AsQueryable(), g).Build());
        }

        public ActionResult Add()
        {
            Db.Insert(new Spreadsheet());
            return Json(new {});
        }

        public ActionResult Save(int id, string name, string value)
        {
            var row = Db.Get<Spreadsheet>(id);

            //this is an inmemory object with a real Db you would use UPDATE Spreadsheets SET {name}={val} where id={id}
            typeof(Spreadsheet).GetProperty(name).SetValue(row, value, null);

            return Json(new {});
        }/*end*/
    }
}