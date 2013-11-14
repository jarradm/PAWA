using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class PurchasesGridController : Controller
    {
        public ActionResult GetItems(GridParams g, string search)
        {
            search = (search ?? "").ToLower();
            var list = Db.Purchases.Where(o => o.Customer.ToLower().Contains(search) || o.Product.ToLower().Contains(search));

            return Json(new GridModelBuilder<Purchase>(list.OrderByDescending(o => o.Id).AsQueryable(), g).Build());
        }
    }
    /*end*/
}