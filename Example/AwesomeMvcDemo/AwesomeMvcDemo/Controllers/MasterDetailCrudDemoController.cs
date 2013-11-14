using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class MasterDetailCrudDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RestaurantGridGetItems(GridParams g)
        {
            var model = new GridModelBuilder<Restaurant>(Db.Restaurants.Where(o => o.IsCreated).AsQueryable(), g).Build();
            return Json(model);
        }

        public ActionResult AddressesGridGetItems(GridParams g, int restaurantId)
        {
            var items = Db.RestaurantAddresses.Where(o => o.RestaurantId == restaurantId).AsQueryable();
            var model = new GridModelBuilder<RestaurantAddress>(items, g).Build();
            return Json(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Db.Delete<Restaurant>(id);
            return Json(new { });
        }

        [HttpPost]
        public ActionResult DeleteAddress(int id)
        {
            Db.Delete<RestaurantAddress>(id);
            return Json(new { });
        }

        public ActionResult Edit(int id)
        {
            var rest = Db.Get<Restaurant>(id);
            return View("Create", new RestaurantInput { Id = id, Name = rest.Name});
        }

        [HttpPost]
        public ActionResult Edit(RestaurantInput input)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", input);
            }

            var rest = Db.Get<Restaurant>(Convert.ToInt32(input.Id));

            rest.Name = input.Name;

            return Json(new { });
        }

        public ActionResult Create()
        {
            // needed so we could add addresses even before the restaurant is created/saved
            var rest = Db.Insert(new Restaurant());

            return View(new RestaurantInput { Id = rest.Id });
        }

        [HttpPost]
        public ActionResult Create(RestaurantInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            
            var restaurant = Db.Get<Restaurant>(input.Id);
            restaurant.Name = input.Name;
            restaurant.IsCreated = true;

            return Json(new { });
        }

        public ActionResult AddAddress(int restaurantId)
        {
            return View(new RestaurantAddressInput { RestaurantId = restaurantId });
        }

        [HttpPost]
        public ActionResult AddAddress(RestaurantAddressInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            Db.Insert(new RestaurantAddress { Line1 = input.Line1, Line2 = input.Line2, RestaurantId = input.RestaurantId });

            return Json(new { });
        }

        public ActionResult EditAddress(int id)
        {
            var address = Db.Get<RestaurantAddress>(id);

            return View(
                "AddAddress",
                new RestaurantAddressInput
                    {
                        Line1 = address.Line1,
                        Line2 = address.Line2,
                        RestaurantId = address.RestaurantId
                    });
        }

        [HttpPost]
        public ActionResult EditAddress(RestaurantAddressInput input)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAddress", input);
            }

            var address = Db.Get<RestaurantAddress>(input.Id);
            address.Line1 = input.Line1;
            address.Line2 = input.Line2;
            return Json(new { });
        }
    }

    public class RestaurantInput
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class RestaurantAddressInput
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        [Required]
        public string Line1 { get; set; }

        public string Line2 { get; set; }
    }
}