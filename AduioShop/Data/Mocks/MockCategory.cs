using AduioShop.Data.Interfaces;
using AduioShop.Data.Models;

namespace AduioShop.Data.Mocks
{
    public class MockCategory : IProductsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category (categoryName: "Headphones", description: "TEXT" ),
                    new Category (categoryName: "Speakers", description: "TEXT1" )
                };
            }
        
        }
    }
}
