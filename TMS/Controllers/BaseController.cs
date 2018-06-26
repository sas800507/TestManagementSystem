using TMS.Services.Abstract;
using TMS.Services.Implements;
using TMS.Services.Implements.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;
using TMS.Models.Cashed;

namespace TMS.Controllers
{
    public class BaseController : Controller
    {
        private readonly IRepository _repository;
        private readonly IAuthentication _authentication;

        public IRepository Repository { get { return _repository; } }
        public IAuthentication Authentication { get { return _authentication; } }

        public BaseController()
        {
            _repository = CachedConstants.Repository;
            _authentication = new Authentication(_repository);
        }

        public ActionResult MainMenu()
        {
            var role = Authentication.GetUserRole();
            return PartialView("MainMenu", role);
        }

        public UserModel LoggedUser { get { return _authentication.GetUser(); } }
    }
}
