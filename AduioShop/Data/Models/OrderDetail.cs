using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AudioShop.Data.Models
{
    public class OrderDetail
    {
        [BindNever]
        public int Id { get; set; }
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public int ProductId { get; set; }
        public int Price { get; set; }
        public virtual Product Product { get; set; }
        [BindNever]
        public virtual Order Order { get; set; }
    }
}
