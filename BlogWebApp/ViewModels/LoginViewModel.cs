using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogWebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Это обязательное поле!")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
