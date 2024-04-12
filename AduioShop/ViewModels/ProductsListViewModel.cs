using AudioShop.Data.Models;

namespace AudioShop.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> allProducts { get; set; }
        public string currentCategory { get; set; }

    
    }

}
