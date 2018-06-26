using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TMS.Helpers
{
    public static class ElementsHelpers
    {
        public static MvcHtmlString Li(this HtmlHelper html, MvcHtmlString url)
        {
            return MvcHtmlString.Create(string.Format("<li>{0}</li>", url));
        }

        public static MvcHtmlString IconLink(this HtmlHelper html, string icon, string url)
        {
            return MvcHtmlString.Create(string.Format("<a href=\"{0}\"><i class=\"{1}\"></i></a>", url, icon));
        }
    }
}