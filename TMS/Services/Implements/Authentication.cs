using TMS.Models;
using TMS.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TMS.Services.Implements
{
    public class Authentication : IAuthentication
    {
        private readonly IRepository _repository;

        public Authentication(IRepository repository)
        {
            _repository = repository;
        }

        public Constants.Constants.UserType GetUserRole()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) return Constants.Constants.UserType.Guest;
            var user = GetUser();
            if (user == null) return Constants.Constants.UserType.Guest;
            return user.UserType;
        }

        public UserModel GetUser()
        {
            var id = HttpContext.Current.User.Identity.Name;
            if (id == null) return null;
            var user = _repository.GetUser(id);
            return user;
        }

        public bool IsAuthenticated()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public bool LogIn(string login, string password, bool rememberMe)
        {
            if (login == null) return false;

            string personId = string.Empty;

            var person = _repository.GetUser(login, password);
            if (person == null) return false;
            personId = person.ID;
            FormsAuthentication.SetAuthCookie(personId, rememberMe);
            System.Web.HttpContext.Current.Session["loggedUser"] = person;
            return true;
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Session["loggedUser"] = null;
        }
    }
}