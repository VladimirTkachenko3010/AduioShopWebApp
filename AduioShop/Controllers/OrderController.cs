using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudioShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly Data.Models.Cart cart;

        public OrderController(IAllOrders allOrders, Data.Models.Cart cart)
        {
            this.allOrders = allOrders;
            this.cart = cart;
        }


        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            cart.CartItems = cart.GetCartItems();

            if (cart.CartItems.Count == 0) 
            {
                ModelState.AddModelError("", "У вас повинні бути товари в кошику!");
            }
            if (cart.CartItems.Count > 0) 
            {
                allOrders.CreateOrder(order);
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("CompleteOrder", "Order");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return RedirectToAction("CompleteOrder", "Order");
            }
            return View(order);
        }


        public IActionResult CompleteOrder()
        {
            ViewBag.Message = "Замовлення успішно оброблене";
            return View();
        }
    }
}
