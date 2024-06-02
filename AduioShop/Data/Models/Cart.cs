using AudioShop.Database;
using Microsoft.EntityFrameworkCore;

namespace AudioShop.Data.Models
{
    public class Cart
    {
        private readonly AudioShopDBContext audioShopDBContext;
        public Cart(AudioShopDBContext audioShopDBContext)
        {
            this.audioShopDBContext = audioShopDBContext;
        }

        public string CartId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = serviceProvider.GetService<AudioShopDBContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new Cart(context)
            {
                CartId = cartId
            };
        }


        public void AddToCart(Product product)
        {
            var cartItem = audioShopDBContext.CartItems
        .FirstOrDefault(ci => ci.CartId == CartId && ci.Product.Id == product.Id);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                audioShopDBContext.CartItems.Add(new CartItem
                {
                    CartId = CartId,
                    Product = product,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            audioShopDBContext.SaveChanges();
        }

        public void UpdateCartItemQuantity(int productId, int quantity)
        {
            var cartItem = audioShopDBContext.CartItems
                .FirstOrDefault(ci => ci.CartId == CartId && ci.Product.Id == productId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                if (cartItem.Quantity < 1)
                {
                    cartItem.Quantity = 1;
                }
                audioShopDBContext.SaveChanges();
            }
        }

        public void RemoveFromCart(int productId)
        {
            var cartItem = audioShopDBContext.CartItems.FirstOrDefault(ci => ci.CartId == CartId && ci.Product.Id == productId);
            if (cartItem != null)
            {
                audioShopDBContext.CartItems.Remove(cartItem);
                audioShopDBContext.SaveChanges();
            }
        }

        public List<CartItem> GetCartItems()
        {
            return audioShopDBContext.CartItems.Where(c => c.CartId == CartId).Include(s => s.Product).ToList();
        }
    }
}
