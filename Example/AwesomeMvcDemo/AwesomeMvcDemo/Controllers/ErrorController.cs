using System;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;

namespace AwesomeMvcDemo.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(Exception error)
        {
            ViewData["message"] = Message(error);
            if (Request.IsAjaxRequest())
            {
                Response.StatusCode = 500;
                if (error is AwesomeDemoException)
                    return PartialView("Expectedp");
                return View("errorp");
            }

            if (error is AwesomeDemoException)
            {
                return View("Expected");
            }
            
            return View("Error");
        }

        private string Message(Exception ex)
        {
            if (ex == null) return "";
            return ex.Message + "\n" + Message(ex.InnerException);
        }

        public ActionResult HttpError404(Exception error)
        {
            Response.StatusCode = 404;
            if(Request.IsAjaxRequest())
            {
                return Content("404 not found");
            }
            return View();
        }

        public ActionResult HttpError505(Exception error)
        {
            return View();
        }
    }
}