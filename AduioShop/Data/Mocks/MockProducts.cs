using AduioShop.Data.Interfaces;
using AduioShop.Data.Models;

namespace AduioShop.Data.Mocks
{
    public class MockProducts : IAllProducts
    {
        private readonly IProductCategory _categoryProducts = new MockCategory();   //?
        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>()
                {
                    new Product(
                        id : 1,
                        productType : "Headphone",
                        brand : "Apple",
                        name : "Powerbeats Pro",
                        description : "TEXT...",
                        shortDesc : "txt...",
                        img: "123",
                        price : 0,
                        isFavorite : false,
                        isAvailible : false,
                        categoryId : 1,
                        category : _categoryProducts.AllCategories.First()
                        )
                };
            }
        }

        public IEnumerable<Product> getFavorite { get; set; }

        public Product getObjectProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }


}
