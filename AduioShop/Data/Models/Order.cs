using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AudioShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введіть ваше Ім'я")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Довжина Ім'я повинна бути від 2 до 25 символів")]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        [RegularExpression(@"^[A-Za-zА-Яа-яЇїІіЄєҐґ' -]+$", ErrorMessage = "Некоректне Ім'я")]
        public string Name { get; set; }

        [Display(Name = "Введіть вашу Фамілію")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Довжина Фамілії повинна бути від 2 до 25 символів")]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        [RegularExpression(@"^[A-Za-zА-Яа-яЇїІіЄєҐґ' -]+$", ErrorMessage = "Некоректна Фамілія")]
        public string Surname { get; set; }

        [Display(Name = "Введіть Адресу доставки замовлення")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "Довжина Адреси доставки повинна бути від 5 до 80 символів")]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        public string Address { get; set; }

        [Display(Name = "Введіть ваш Номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Введіть правильний номер телефону")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Довжина Номеру телефону повинна бути від 10 до 20 символів")]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        public string Phone { get; set; }

        [Display(Name = "Введіть вашу Електронну пошту")]
        [DataType(DataType.EmailAddress)]
        [StringLength(45, MinimumLength = 12, ErrorMessage = "Довжина Електронної пошти повинна бути від 12 до 45 символів")]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        [EmailAddress(ErrorMessage = "Введіть правильний Email")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        [BindNever]
        public List<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
