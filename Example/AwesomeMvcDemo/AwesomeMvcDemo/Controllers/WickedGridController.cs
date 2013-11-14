using System.Linq;
using System.Web.Mvc;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class WickedGridController : Controller
    {
        public ActionResult GetItems(GridParams g)
        {
            var items = new[] { new Wicked { Name = "" } };

            return Json(new GridModelBuilder<Wicked>(items.AsQueryable(), g).Build());
        }
    }

    public class Wicked
    {
        public string Name { get; set; }
    }
}