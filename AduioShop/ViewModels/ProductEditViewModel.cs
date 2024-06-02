using AudioShop.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AudioShop.ViewModels
{
    public class ProductEditViewModel
    {
        public Product Product { get; set; }
        [Required(ErrorMessage ="Зображення товару обов'язкові")]
        public List<IFormFile> Images { get; set; }
        public List<bool> DeletedImageUrls { get; set; }
        [BindNever]
        public IEnumerable<Category> CategoriesList { get; set; }
        [Required(ErrorMessage = "Категорія товару обов'язкова")]
        public IEnumerable<string> ProductTypes { get; set; }
    }
}
