using System.ComponentModel.DataAnnotations;

namespace AudioShop.Data.Models
{
    public class Category
    {
        /// <summary>
        /// CategoryId
        /// </summary>
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Type is required")]
        /// <summary>
        /// Category for product type
        /// </summary>
        public string ProductType { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }

        public Category(int id, string productType, string description)
        {
            Id = id;
            ProductType = productType;
            Description = description;
        }
        public Category(string productType, string description)
        {
            ProductType = productType;
            Description = description;
        }
        public Category()
        {
        }
    }
}
