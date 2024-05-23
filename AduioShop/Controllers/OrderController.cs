﻿using AudioShop.Data.Interfaces;
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

        // Проверяем корзину перед отображением страницы оформления заказа
        public IActionResult Checkout()
        {
            cart.CartItems = cart.GetCartItems();

            if (cart.CartItems.Count == 0)
            {
                // Добавляем ошибку модели и возвращаем на страницу корзины
                ModelState.AddModelError("", "Ваш кошик порожній. Додайте товари перед оформленням замовлення.");
                return RedirectToAction("Index", "Cart");
            }

            return View();
        }

        // Обработка данных заказа
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            cart.CartItems = cart.GetCartItems();

            if (cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас повинні бути товари в кошику");
            }

            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("CompleteOrder");
            }
            else
            {
                ViewBag.ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return View(order);
            }
        }

        // Отображение сообщения об успешном заказе
        public IActionResult CompleteOrder()
        {
            ViewBag.Message = "Замовлення успішно оброблене";
            return View();
        }
    }
}
