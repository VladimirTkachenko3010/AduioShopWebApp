using AudioShop.Data.Interfaces;
using AudioShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AudioShop.Controllers
{
    public class CartController : Controller
    {

        private IAllProducts _productRepository;
        private readonly Data.Models.Cart _cart;

        public CartController(IAllProducts productRepository, Data.Models.Cart cart)
        {
            _productRepository = productRepository;
            _cart = cart;
        }

        public ViewResult Index()
        {
            var items = _cart.GetCartItems();
            _cart.CartItems = items;

            var obj = new CartViewModel
            {
                Cart = _cart,
            };

            return View(obj);
        }


        public RedirectToActionResult AddToCart(int id)
        {
            var item = _productRepository.Products.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _cart.AddToCart(item);
            }

            return RedirectToAction("Index");

        }
    }
}
