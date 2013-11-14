using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{/*begin*/
    public class GroupingGridController : Controller
    {
        public ActionResult GetItems(GridParams g, bool collapsed)
        {
            //passing 2 Functions MakeFooter and MakeHeader
            return Json(new GridModelBuilder<Lunch>(Db.Lunches.AsQueryable(), g)
            {
                MakeFooter = MakeFooter,
                MakeHeader = gr => 
                {
                    //get first item in the group
                    var first = gr.Items.First();
                    
                    //get the grouped column value for the first item
                    var val = AweUtil.GetColumnValue(gr.Column, first).Single();
                    
                    return new GroupHeader
                    {
                        Content = string.Format(" {0} : {1} ( Count = {2}, Max Price = {3} )", 
                                                gr.Header, val, gr.Items.Count(), gr.Items.Max(o => o.Price)),
                        Collapsed = collapsed
                    };
                }
            }.Build());
        }

        private object MakeFooter(GroupInfo<Lunch> info)
        {
            //will add the word Total at the grid level footer (Level == 0)
            var pref = info.Level == 0 ? "Total " : "";

            return new
                    {
                        Food = pref + " count = " + info.Items.Count(),
                        Location = info.Items.Select(o => o.Location).Distinct().Count() + " distinct locations",
                        Date = pref + " max: " + info.Items.Max(o => o.Date).Date.ToShortDateString(),
                        Price = info.Items.Sum(o => o.Price)
                    };
        }

    }/*end*/
}