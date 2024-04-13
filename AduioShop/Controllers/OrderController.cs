using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;
using AudioShop.Database;
using Microsoft.AspNetCore.Mvc;

namespace AudioShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly Cart cart;

        public OrderController(IAllOrders allOrders, Cart cart)
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

            if(cart.CartItems.Count == 0) 
            {
                ModelState.AddModelError("","У вас повинні бути товари в кошику!");
            }
            if(ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
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
