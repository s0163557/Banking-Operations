using System.ComponentModel.DataAnnotations;

namespace Banking_Operations.Models
{
    public class ContactsModel
    {
        [Display(Name = "Введите имя")]
        [Required(ErrorMessage = "Поле должно быть заполнено!")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        [Required(ErrorMessage = "Поле должно быть заполнено!")]
        public string SurName { get; set; }

        [Display(Name = "Введите возраст")]
        [Required(ErrorMessage = "Поле должно быть заполнено!")]
        public string Age { get; set; }

        [Display(Name = "Введите почту")]
        [Required(ErrorMessage = "Поле должно быть заполнено!")]
        public string Mail { get; set; }

        [Display(Name = "Введите сообщение")]
        [Required(ErrorMessage = "Поле должно быть заполнено!")]
        [StringLength(100, ErrorMessage = "Текст не более 100 символов")]
        public string Message { get; set; }
    }
}
