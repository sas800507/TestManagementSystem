using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Services.Implements;
using TMS.Services.Implements.Repository;

namespace TMS.Services
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public Constants.Constants.UserType SdRole { get; set; }

        public AuthAttribute()
        {
            SdRole = Constants.Constants.UserType.Guest;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var auth = new Authentication(new Repository());
            if (auth.GetUserRole() < SdRole) return false;
            return true;
        }
    }
}