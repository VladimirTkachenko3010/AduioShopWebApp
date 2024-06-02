using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioShop.Data.Models
{
    public class Product
    {
        /// <summary>
        /// ProductId
        /// </summary>
        public int Id { get; set; }
        [Required(ErrorMessage = "Тип продукту обов'язковий")]
        public string ProductType { get; set; }
        [Required(ErrorMessage = "Бренд обов'язковий")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Назва обов'язкова")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Опис обов'язковий")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Короткий опис обов'язковий")]
        public string ShortDesc { get; set; }
        [Required(ErrorMessage = "Зображення обов'язкове")]
        public string Img { get; set; }
        [Required(ErrorMessage = "Ціна обов'язкова")]
        [Range(0.01, int.MaxValue, ErrorMessage = "Ціна повинна бути більшою за нуль")]
        public int Price { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsAvailible { get; set; }
        [BindNever]
        [NotMapped]
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public List<ProductImages> ImageUrls { get; set; }
        [Required(ErrorMessage = "Категорія обов'язкова")]
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
        }
    }
}
