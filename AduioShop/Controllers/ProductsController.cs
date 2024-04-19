using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;
using AudioShop.Database;
using AudioShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AudioShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAllProducts allProducts;
        private readonly IProductsCategory productsCategory;

        public ProductsController(IAllProducts allProducts, IProductsCategory productsCategory)
        {
            this.allProducts = allProducts;
            this.productsCategory = productsCategory;
        }

        public IActionResult GetSearch(string searchTerm)
        {
            var products = allProducts.SearchProducts(searchTerm);  
            return View(products);
        }

        [Route("Products/Catalog")]
        [Route("Products/Catalog/{category}")]
        public IActionResult Catalog(string category)
        {

            string _category = category;
            IEnumerable<Product> products;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                products = allProducts.Products.OrderBy(x => x.Id);
            }
            else
            {
                #region if-else категории(если нужно только 2 категории)
                //if (string.Equals("Headphones", category, StringComparison.OrdinalIgnoreCase))
                //{
                //    products = allProducts.Products.Where(i => i.Category.ProductType.Equals("Headphones")).OrderBy(x => x.Id);
                //}
                //else
                //{
                //    if (string.Equals("Speakers", category, StringComparison.OrdinalIgnoreCase))
                //    {
                //        products = allProducts.Products.Where(i => i.Category.ProductType.Equals("Speakers")).OrderBy(x => x.Id);
                //    }
                //}
                #endregion
                switch (category.ToLowerInvariant())
                {
                    case "headphones":
                        products = allProducts.Products
                            .Where(i => i.Category.ProductType.Equals("Headphones", StringComparison.OrdinalIgnoreCase))
                            .OrderBy(x => x.Id);
                        currentCategory = "Навушники";
                        break;
                    case "speakers":
                        products = allProducts.Products
                            .Where(i => i.Category.ProductType.Equals("Speakers", StringComparison.OrdinalIgnoreCase))
                            .OrderBy(x => x.Id);
                        currentCategory = "Портативні колонки";
                        break;
                    default:
                        products = Enumerable.Empty<Product>(); // добавить другие категории?..
                        break;
                }
                
            }

            var productObj = new ProductsListViewModel
            {
                allProducts = products,
                currentCategory = currentCategory
            };

            ViewBag.Title = "Headphones page";

            return View("Catalog", productObj);
        }
    }
}
