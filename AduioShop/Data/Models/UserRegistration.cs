using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AudioShop.Data.Models
{
    public class UserRegistration
    {
        [Required(ErrorMessage = "Логін обов'язковий"), MaxLength(40)]
        public string LoginProp { get; set; }
        [Required(ErrorMessage = "Електронна пошта обов'язкова"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пароль обов'язковий"), DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Ім'я обов'язкове")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Прізвище обов'язкове")]
        public string Surname { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
