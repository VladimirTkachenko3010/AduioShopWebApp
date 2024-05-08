using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;
using AudioShop.Database;
using AudioShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

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
                        products = Enumerable.Empty<Product>();
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


        public IActionResult ProductDetails(int id)
        {
            var product = allProducts.getObjectProduct(id);

            if (product == null)
            {
                ViewBag.ErrorMessage = "Товар не найден";
                return View("Error"); 
            }
            else
            {
                var imgFolder = "img"; 
                var imgPath = Path.Combine(imgFolder, product.ProductType); 
                string[] productFiles = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgPath), $"{product.Name}-*.jpg");
                if (productFiles != null)
                {
                    product.ImageUrls = productFiles.Select(file => $"/{imgPath}/{Path.GetFileName(file)}").ToList();
                }
                else
                {
                    product.ImageUrls = new List<string>();
                }
            }
            return View(product); 
        }

    }
}
