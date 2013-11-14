using AwesomeMvcDemo.ViewModels;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;

namespace AwesomeMvcDemo.Controllers
{
    public class PurchasesCrudDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Db.Delete<Purchase>(id);
            return Json(new { });
        }

        public ActionResult Edit(int id)
        {
            var o = Db.Get<Purchase>(id);
            var input = new PurchaseInput
                {
                    Customer = o.Customer,
                    Product = o.Product,
                    Date = o.Date,
                    Quantity = o.Quantity
                };

            return View(input);
        }

        [HttpPost]
        public ActionResult Edit(PurchaseInput input)
        {
            if (!ModelState.IsValid) return View(input);

            var o = Db.Get<Purchase>(input.Id);
            o.Customer = input.Customer;
            o.Date = input.Date.Value;
            o.Product = input.Product;
            o.Quantity = input.Quantity;
            Db.Update(o);
            return Json(new { });
        }

        public ActionResult Create()
        {
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Create(PurchaseInput input)
        {
            if (!ModelState.IsValid) return View("Edit", input);
            var o = new Purchase
                {
                    Customer = input.Customer,
                    Date = input.Date.Value,
                    Quantity = input.Quantity,
                    Product = input.Product
                };
            Db.Insert(o);
            return Json(new { });
        }
    }
}