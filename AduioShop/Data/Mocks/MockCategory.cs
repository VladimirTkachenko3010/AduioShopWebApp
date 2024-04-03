using AduioShop.Data.Interfaces;
using AduioShop.Data.Models;

namespace AduioShop.Data.Mocks
{
    public class MockCategory : IProductCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category (categoryName: "Headphones", description: "TEXT" ),
                    new Category (categoryName: "Dynamics", description: "TEXT1" )
                };
            }
        
        }
    }
}
