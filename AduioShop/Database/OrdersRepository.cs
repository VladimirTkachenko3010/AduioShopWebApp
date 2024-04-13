using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudioShop.Database
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AudioShopDBContext dbContext;
        private readonly Cart cart;

        public OrdersRepository(AudioShopDBContext dbContext, Cart cart)
        {
            this.dbContext = dbContext;
            this.cart = cart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();    //?
            List<CartItem> items = cart.CartItems;
            foreach (var elem in items)
            {
                var detail = new OrderDetail()
                {
                    ProductId = elem.Product.Id,
                    OrderId = order.Id,
                    Price = elem.Product.Price
                };
                dbContext.OrderDetails.Add(detail);
            }
            dbContext.SaveChanges();
        }


    }
}
