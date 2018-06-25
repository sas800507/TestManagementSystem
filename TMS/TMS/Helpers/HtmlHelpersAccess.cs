using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Helpers
{
    public static class HtmlHelpersAccess
    {
        public static MvcHtmlString AccessAdmin(this MvcHtmlString value, Constants.Constants.UserType userType)
        {
            if (userType != Constants.Constants.UserType.Admin) return MvcHtmlString.Empty;
            return value;
        }

        public static MvcHtmlString AccessManager(this MvcHtmlString value, Constants.Constants.UserType userType)
        {
            if (userType < Constants.Constants.UserType.Manager) return MvcHtmlString.Empty;
            return value;
        }

        public static MvcHtmlString AccessStaff(this MvcHtmlString value, Constants.Constants.UserType userType)
        {
            if (userType < Constants.Constants.UserType.Staff) return MvcHtmlString.Empty;
            return value;
        }

        public static MvcHtmlString AccessUser(this MvcHtmlString value, Constants.Constants.UserType userType)
        {
            if (userType < Constants.Constants.UserType.User) return MvcHtmlString.Empty;
            return value;
        }

        public static MvcHtmlString AccessLogged(this MvcHtmlString value)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated) return value;
            return MvcHtmlString.Empty;
        }
    }
}