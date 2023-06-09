using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogWebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Это обязательное поле!")]
        [Display(Name = "Логин")]
        public string NicName { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Это обязательное поле!")]
        [Compare("Password", ErrorMessage = "Проверьте правильность пароля")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Это обязательное поле!")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        
    }
}
