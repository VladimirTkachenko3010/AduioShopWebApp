using AudioShop.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AudioShop.ViewModels
{
    public class ProductEditViewModel
    {
        public Product Product { get; set; }
        public List<IFormFile> Images { get; set; }
        // Список для загрузки новых изображений
        public List<IFormFile> NewImages { get; set; } = new List<IFormFile>();
        // Список для удаления изображений
        public List<bool> DeletedImageUrls { get; set; } = new List<bool>();
        [BindNever]
        public IEnumerable<Category> CategoriesList { get; set; }

    }
}
