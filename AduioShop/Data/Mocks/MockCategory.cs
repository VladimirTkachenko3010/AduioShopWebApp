using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;

namespace AudioShop.Data.Mocks
{
    public class MockCategory : IProductsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category (productType: "Headphones", description: "TEXT" ),
                    new Category (productType: "Speakers", description: "TEXT1" )
                };
            }
        
        }
    }
}
