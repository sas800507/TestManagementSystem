using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Services;
using UserType = TMS.Constants.Constants.UserType;

namespace TMS.Controllers
{
    [Authorize]
    [Auth(SdRole = UserType.User)]
    public class RequrementsController : BaseController
    {
        public ActionResult Index(string folId = "")
        {
            return View();
        }
    }
}
