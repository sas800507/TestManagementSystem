using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class LoginModel
    {
        [UIHint("Login")]
        public string Login { get; set; }
        [UIHint("Password")]
        public string Password { get; set; }
        [UIHint("RememberMe")]
        public bool RememberMe { get; set; }

        public LoginModel()
        {
            Login = string.Empty;
            Password = string.Empty;
            RememberMe = false;
        }
    }
}