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
    [Auth(SdRole = UserType.Manager)]
    public class SystemController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Folders(string parent = "")
        {
            var model = Repository.GetFolderList(parent);

            return View(model);
        }
    }
}
