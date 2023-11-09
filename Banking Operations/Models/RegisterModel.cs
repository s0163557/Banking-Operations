using System.ComponentModel.DataAnnotations;

namespace Banking_Operations.Models
{
    public class RegisterModel
    {
        [Display(Name = "Введите почту")]
        [Required(ErrorMessage = "Необходимо ввести почту")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Необходимо ввести пароль")]
        [Display(Name = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Необходимо подтвердить пароль")]
        [Display(Name = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }

    }
}
