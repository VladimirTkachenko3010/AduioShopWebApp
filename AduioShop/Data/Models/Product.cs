﻿namespace AduioShop.Data.Models
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
        public int Price { get; set; }= 0;
        public bool IsFavorite { get; set; }
        public bool IsAvailible { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Product(int id, string productType, string brand, string name, string description,
            string shortDesc, string img, int price, bool isFavorite, bool isAvailible, int categoryId, Category category )
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
        }
    }
}
