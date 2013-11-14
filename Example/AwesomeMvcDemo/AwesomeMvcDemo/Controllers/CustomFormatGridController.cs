using System;
using System.Linq;
using System.Web.Mvc;

using AwesomeMvcDemo.Models;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /*begin*/
    public class CustomFormatGridController : Controller
    {
        public ActionResult GetItems(GridParams g)
        {
            return Json(new GridModelBuilder<Lunch>(Db.Lunches.AsQueryable(), g)
                {
                    Map = o => new { o.Person, o.Price, o.Food, Date = o.Date.ToString("dd MMMM yyyy"), o.Location },
                    MakeHeader = gr =>
                        {
                            var value = AweUtil.GetColumnValue(gr.Column, gr.Items.First()).Single();
                            var strVal = gr.Column == "Date" ? ((DateTime)value).ToString("dd MMMM yyyy") :
                                         gr.Column == "Price" ? value + " GBP" : value.ToString();
                        
                            return new GroupHeader {Content = gr.Header + " - " + strVal};
                        } }.Build());
        }
    }
    /*end*/
}