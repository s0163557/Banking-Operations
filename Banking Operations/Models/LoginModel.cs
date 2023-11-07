using System.ComponentModel.DataAnnotations;

namespace Banking_Operations.Models
{
    public class LoginModel
    {
        [Display(Name = "Введите почту")]
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public bool IsPasswordCorrect {get; set;}

    }
}
