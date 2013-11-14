using System;
using System.Web.Mvc;

namespace AwesomeMvcDemo.Areas.Test.Controllers
{
    public class PopupErrorController : Controller
    {
        public ActionResult ShowPopup()
        {
            throw new Exception("Popup example error message");
        }

        public ActionResult ShowPopupForm()
        {
            throw new Exception("PopupForm example error message");
        }
    }
}