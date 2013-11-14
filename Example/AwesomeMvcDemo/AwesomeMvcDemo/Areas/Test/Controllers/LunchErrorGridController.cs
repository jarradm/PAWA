using System;
using System.Web.Mvc;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Areas.Test.Controllers
{
    public class LunchErrorGridController : Controller
    {
        public ActionResult GetItems(GridParams g, string person, string food)
        {
            throw new Exception("grid example error message");
        }
    }
}