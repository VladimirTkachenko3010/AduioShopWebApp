namespace AudioShop.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Price { get; set; }
        public string CartId {  get; set; }

    }
}
