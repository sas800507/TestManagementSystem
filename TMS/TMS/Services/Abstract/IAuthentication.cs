using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Constants;
using TMS.Models;

namespace TMS.Services.Abstract
{
    public interface IAuthentication
    {
        Constants.Constants.UserType GetUserRole();

        bool IsAuthenticated();
        bool LogIn(string login, string password, bool rememberMe);
        UserModel GetUser();
        void LogOut();
    }
}
