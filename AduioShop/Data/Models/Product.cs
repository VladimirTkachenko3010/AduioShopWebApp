using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioShop.Data.Models
{
    public class Product
    {
        /// <summary>
        /// ProductId
        /// </summary>
        public int Id { get; set; }
        public string ProductType { get; set; }   //headphones or dynamics, etc
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDesc { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsAvailible { get; set; }
        [BindNever]
        [NotMapped]
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public List<ProductImages> ImageUrls { get; set; }
        public int CategoryId { get; set; } // Foreign key property
        [BindNever]
        public virtual Category Category { get; set; }  // Navigation property

        public Product()
        {
            
        }

        public Product(int id, string productType, string brand, string name, string description,
            string shortDesc, string img, int price, bool isFavorite, bool isAvailible, List<ProductImages> imageUrls, int categoryId, Category category)  
        {
            Id = id;
            ProductType = productType;
            Brand = brand;
            Name = name;
            Description = description;
            ShortDesc = shortDesc;
            Img = img;
            Price = price;
            IsFavorite = isFavorite;
            IsAvailible = isAvailible;
            CategoryId = categoryId;
            Category = category; 
            ImageUrls = imageUrls;

            //SearchTerm = searchTerm;
        }

        public Product(string productType, string brand, string name, string description,
           string shortDesc, string img, int price, bool isFavorite, bool isAvailible, List<ProductImages> imageUrls, int categoryId, Category category)
        {
            ProductType = productType;
            Brand = brand;
            Name = name;
            Description = description;
            ShortDesc = shortDesc;
            Img = img;
            Price = price;
            IsFavorite = isFavorite;
            IsAvailible = isAvailible;
            CategoryId = categoryId;
            Category = category;
            ImageUrls = imageUrls;
            //SearchTerm = searchTerm;
        }
    }
}
