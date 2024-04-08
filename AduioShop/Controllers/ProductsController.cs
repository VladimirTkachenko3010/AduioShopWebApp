using AduioShop.Data.Interfaces;
using AudioShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AduioShop.Controllers
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



        public IActionResult Catalog()
        {
            ViewBag.Title = "Headphones page";
            ProductsListViewModel obj = new ProductsListViewModel();
            obj.allProducts = allProducts.Products;
            obj.currentCategory = "Headphones";
            return View("Catalog", obj);
        }
    }
}
