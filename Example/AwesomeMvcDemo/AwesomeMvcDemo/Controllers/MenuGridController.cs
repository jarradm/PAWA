using System;
using System.Linq;
using System.Web.Mvc;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    /// <summary>
    /// Grid used as the menu on left
    /// </summary>
    public class MenuGridController : Controller
    {
        public ActionResult GetItems(GridParams g, string controller, string action)
        {
            var items = MySiteMap.Items.ToList();

            Func<string, string, bool> equals = (a, b) => a.Equals(b, StringComparison.OrdinalIgnoreCase);

            var selectedItem = items.SingleOrDefault(o => equals(o.Controller, controller) && equals(o.Action, action));

            if (selectedItem != null)
            {
                var selectedGroup = items.Where(o => o.GroupId == selectedItem.GroupId).ToList();

                // making sure the GroupId for the selected group will be the lowest so the selected group will always be at the top
                // grid is ordered by GroupId
                foreach (var menuItem in selectedGroup)
                {
                    items.Remove(menuItem);
                    items.Add(new SiteMapItem
                                  {
                                      Action = menuItem.Action,
                                      Controller = menuItem.Controller,
                                      GroupId = menuItem.GroupId - 1000,
                                      GroupTitle = menuItem.GroupTitle,
                                      Title = menuItem.Title
                                  });
                }
            }

            //disable paging, an alternative would be to set pagesize to MySiteMap.Items.Count
            g.Paging = false;
            
            return Json(new GridModelBuilder<SiteMapItem>(items.AsQueryable(), g)
            {
                MakeHeader = info =>
                {
                    dynamic f = info.Items.First();

                    // setting a custom persistence key to keep it consistent (doing this because we've changed the GroupId above ^)
                    // without this same group depending on if it is selected or not could be "$GroupId-997" or "$GroupId3"
                    return new GroupHeader { Content = f.GroupTitle, Key = "$" + (f.GroupId < 0 ? f.GroupId + 1000 : f.GroupId) };
                },
                Map = mi => new
                {
                    mi.Action,
                    mi.Controller,
                    mi.GroupId,
                    mi.Title,
                    Url = Url.Action(mi.Action, mi.Controller),
                    Selected = equals(mi.Controller, controller) && equals(mi.Action, action) ? "selected" : ""
                },
            }.Build());
        }
    }
}