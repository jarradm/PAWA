using System;
using System.Web.Mvc;

namespace AwesomeMvcDemo.Areas.Test.Controllers
{
    public class MealsErrorMultiLookupController : Controller
    {
        public ActionResult GetItems(int[] v)
        {
            throw new Exception("MultiLookup GetItems example error message");
        }

        public ActionResult Search(string search, int[] selected, int page)
        {
            throw new Exception("MultiLookup Search example error message");
        }

        public ActionResult Selected(int[] selected)
        {
            throw new Exception("MultiLookup Selected example error message");
        }
    }
}
