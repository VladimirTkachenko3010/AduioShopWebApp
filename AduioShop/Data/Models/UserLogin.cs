using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AudioShop.Data.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Логін обов'язковий"), MaxLength(40)]
        public string LoginProp { get; set; }
        [Required(ErrorMessage = "Електронна пошта обов'язкова"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обов'язковий"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
