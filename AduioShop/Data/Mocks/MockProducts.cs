using AduioShop.Data.Interfaces;
using AduioShop.Data.Models;

namespace AduioShop.Data.Mocks
{
    public class MockProducts : IAllProducts
    {
        private readonly IProductsCategory _categoryProducts = new MockCategory();   //?
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
                        ),
                    new Product(
                        id : 2,
                        productType : "Headphone",
                        brand : "Apple",
                        name : "AirPods Max Silver",
                        description : "TEXT...",
                        shortDesc : "txt...",
                        img: "123",
                        price : 0,
                        isFavorite : false,
                        isAvailible : false,
                        categoryId : 1,
                        category : _categoryProducts.AllCategories.First()
                        ),
                    new Product(
                        id : 3,
                        productType : "Headphone",
                        brand : "Apple",
                        name : "AirPods 3",
                        description : "TEXT...",
                        shortDesc : "txt...",
                        img: "123",
                        price : 0,
                        isFavorite : false,
                        isAvailible : false,
                        categoryId : 1,
                        category : _categoryProducts.AllCategories.First()
                        ),
                     new Product(
                        id : 4,
                        productType : "Speakers",
                        brand : "JBL",
                        name : "Charge 5",
                        description : "TEXT...",
                        shortDesc : "txt...",
                        img: "123",
                        price : 0,
                        isFavorite : false,
                        isAvailible : false,
                        categoryId : 2,
                        category : _categoryProducts.AllCategories.Last()
                        ),
                     new Product(
                        id : 5,
                        productType : "Speakers",
                        brand : "JBL",
                        name : "Charge 4",
                        description : "TEXT...",
                        shortDesc : "txt...",
                        img: "123",
                        price : 0,
                        isFavorite : false,
                        isAvailible : false,
                        categoryId : 2,
                        category : _categoryProducts.AllCategories.Last()
                        ),
                    new Product(
                        id : 6,
                        productType : "Speakers",
                        brand : "JBL",
                        name : "Xtreme 2",
                        description : "TEXT...",
                        shortDesc : "txt...",
                        img: "123",
                        price : 0,
                        isFavorite : false,
                        isAvailible : false,
                        categoryId : 2,
                        category : _categoryProducts.AllCategories.Last()
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
