using System.ComponentModel.DataAnnotations;

namespace TMS.Models
{
    public class UserModel : BaseModel
    {
        [Display(Name="Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public TMS.Constants.Constants.UserType UserType { get; set; }
    }
}