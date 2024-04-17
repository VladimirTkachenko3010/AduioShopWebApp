using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AudioShop.Data.Models
{
    public class UserLogin
    {
        [Required, MaxLength(40)]
        public string LoginProp { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        //[BindNever]
        //public string Name { get; set; }
        //[BindNever]
        //public string Surname { get; set; }
        //[BindNever]
        //public string PhoneNumber { get; set; } = string.Empty;
    }
}
