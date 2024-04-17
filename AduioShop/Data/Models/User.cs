using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AudioShop.Data.Models
{
    public class User : IdentityUser
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [BindNever]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
