using AudioShop.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AudioShop.ViewModels
{
    public class ProductEditViewModel
    {
        public Product Product { get; set; }
        [BindNever]
        public IEnumerable<Category> CategoriesList { get; set; }
        //public List<IFormFile> Images { get; set; }
        //public string FilePath { get; set; }

    }
}
