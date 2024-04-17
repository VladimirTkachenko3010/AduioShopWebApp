using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AudioShop.Data.Models
{
    public class UserRegistration
    {
        [Required, MaxLength(40)]
        public string LoginProp { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
