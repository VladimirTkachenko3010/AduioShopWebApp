namespace AduioShop.Data.Models
{
    public class Category
    {
        /// <summary>
        /// CategoryId
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Category for product type
        /// </summary>
        public string ProductType { get; set; }
        public string CategoryName { get; set; }
        public string Brand { get; set; }
        public int PriceRange { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }

        public Category(int id, string productType, string brand, int priceRange, string description)
        {
            Id = id;
            ProductType = productType;
            Brand = brand;
            PriceRange = priceRange;
            Description = description;
        }
        public Category(string categoryName, string description)
        {
            CategoryName = categoryName;
            Description = description;
            
        }

    }
}
