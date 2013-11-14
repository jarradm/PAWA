using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeMvcDemo.Controllers
{
    public class ChangeThemeController : Controller
    {
        private const string DefaultTheme = "bui";

        private const string CookieName = "awedemotheme";

        //theme, jqueryUiTheme
        readonly IDictionary<string, string> themes = new Dictionary<string, string>
            {
                {"bui", "smoothness"}, 
                {"met", "smoothness"}, 
                {"gui","smoothness"},
                {"gui2", "smoothness"}, 
                {"gui3", "start"},
                {"compact", "smoothness"}, 
                {"start","start"}, 
                {"black-tie","black-tie"}, 
            };

        public ActionResult Index()
        {
            var currentTheme = DefaultTheme;

            if (Request.Cookies[CookieName] != null)
                currentTheme = Request.Cookies[CookieName].Value;

            return View(themes.Select(theme => new SelectListItem
            {
                Text = theme.Key,
                Value = theme.Key + "|" + theme.Value,
                Selected = theme.Key == currentTheme
            }));
        }

        [HttpPost]
        public ActionResult Change(string s)
        {
            Response.Cookies.Add(new HttpCookie(CookieName, s) { Expires = DateTime.Now.AddDays(30) });
            return new EmptyResult();
        }

        public string GetTheme()
        {
            var s = DefaultTheme;
            if (Request.Cookies[CookieName] != null && themes.ContainsKey(Request.Cookies[CookieName].Value))
            {
                s = Request.Cookies[CookieName].Value;
            }

            return s;
        }

        public string GetJqTheme()
        {
            var s = DefaultTheme;
            if (Request.Cookies[CookieName] != null && themes.ContainsKey(Request.Cookies[CookieName].Value))
            {
                s = Request.Cookies[CookieName].Value;
            }

            return themes[s];
        }
    }
}