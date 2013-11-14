using System.Linq;
using System.Web.Mvc;

using AwesomeMvcDemo.Models;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class MessagesGridController : Controller
    {
        public ActionResult GetItems(GridParams g)
        {
            return Json(new GridModelBuilder<Message>(Db.Messages.AsQueryable(), g)
                {
                    Map = o => new
                    {
                        o.Id,
                        o.From, 
                        o.Subject, 
                        o.DateReceived, 
                        Body = o.Body.Length < 73 ? o.Body : o.Body.Substring(0, 73),
                        o.IsRead,
                        RowClass = o.IsRead ? "" : "notRead"
                    }
                }.Build());
        }
    }
}