namespace AudioShop.Data.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrls { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
