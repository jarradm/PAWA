using System;
using System.Web;
using System.Web.Mvc;

namespace AwesomeMvcDemo
{
    public static class CustomHelpers
    {
        public static IHtmlString Csourcem(this HtmlHelper html, string path)
        {
            path = html.ViewContext.HttpContext.Server.MapPath(@"~\ViewModels\" + path);
            var lines = System.IO.File.ReadAllText(path);
            var start = lines.IndexOf("/*begin*/", StringComparison.Ordinal) + 10;
            var end = lines.IndexOf("/*end*/", StringComparison.Ordinal);
            var str = lines.Substring(start, end - start);
            return new MvcHtmlString(ParseStrToCode(str));
        }

        /// <summary>
        /// get the string value of the controller code between the /*begin*/ and /*end*/ comment blocks 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IHtmlString Csource(this HtmlHelper html, string path)
        {
            string res;
            path = html.ViewContext.HttpContext.Server.MapPath(@"~\Controllers\" + path);
            var lines = System.IO.File.ReadAllText(path);
            var start = lines.IndexOf("/*begin*/", StringComparison.Ordinal);

            if (start == -1)
            {
                res = lines;
            }
            else
            {
                start += 10;
                var end = lines.IndexOf("/*end*/", StringComparison.Ordinal);
                res = lines.Substring(start, end - start).Trim('\n', '\r');
            }

            return new MvcHtmlString(ParseStrToCode(res));
        }

        /// <summary>
        /// get the string value of the view code located between the begin+key and end+key comment blocks
        /// </summary>
        /// <param name="html"></param>
        /// <param name="path"></param>
        /// <param name="k">key</param>
        /// <returns></returns>
        public static IHtmlString Source(this HtmlHelper html, string path, object k = null)
        {
            string res;
            var key = k == null ? "" : k.ToString();
            path = html.ViewContext.HttpContext.Server.MapPath(@"~\Views\" + path);
            var lines = System.IO.File.ReadAllText(path);
            var start = lines.IndexOf("<%--begin" + key + "--%>", StringComparison.Ordinal);

            if (start == -1)
            {
                res = lines;
            }
            else
            {
                start += 14 + key.Length;
                var end = lines.IndexOf("<%--end" + key + "--%>", StringComparison.Ordinal);
                res = lines.Substring(start, end - start).Trim('\n', '\r');
            }

            return new MvcHtmlString(ParseStrToCode(res));
        }

        private static string ParseStrToCode(string str)
        {
            str = str.Replace("\r", string.Empty)
                .Replace("&", "&amp;")
                .Replace("\"", "&quot;")
                .Replace("'", "&#39;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\n", "<br/>");

            return str;
        }
    }

    public static class JQueryDate
    {
        public static string ConvertDateFormat(string format)
        {
            var currentFormat = format;

            currentFormat = currentFormat.Replace("dddd", "DD");
            currentFormat = currentFormat.Replace("ddd", "D");

            if (currentFormat.Contains("MMMM"))
            {
                currentFormat = currentFormat.Replace("MMMM", "MM");
            }
            else if (currentFormat.Contains("MMM"))
            {
                currentFormat = currentFormat.Replace("MMM", "M");
            }
            else if (currentFormat.Contains("MM"))
            {
                currentFormat = currentFormat.Replace("MM", "mm");
            }
            else
            {
                currentFormat = currentFormat.Replace("M", "m");
            }

            currentFormat = currentFormat.Contains("yyyy") ? currentFormat.Replace("yyyy", "yy") : currentFormat.Replace("yy", "y");

            return currentFormat;
        }
    }
}