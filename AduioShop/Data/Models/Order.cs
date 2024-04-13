using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AudioShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введіть ваше Ім'я")]
        [StringLength (25)]
        [Required(ErrorMessage ="Довжина Ім'я повинна бути не менш ніж 5 символів")]
        public string Name { get; set; }

        [Display(Name = "Введіть вашу Фамілію")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина Фамілії повинна бути не менш ніж 5 символів")]
        public string Surname { get; set; }

        [Display(Name = "Введіть вашу Номер відділення Нової Пошти")]
        [StringLength(5)]
        [Required(ErrorMessage = "Довжина Номеру відділення Нової Пошти повинна бути не менш ніж 1 символ")]
        public string Address { get; set; }

        [Display(Name = "Введіть ваш Номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Довжина Номеру телефону повинна бути не менш ніж 10 символів")]
        public string Phone { get; set; }

        [Display(Name = "Введіть вашу Електронну пошту")]
        [DataType(DataType.EmailAddress)]
        [StringLength(45)]
        [Required(ErrorMessage = "Довжина Електронної пошти повинна бути не менш ніж 12 символів")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
