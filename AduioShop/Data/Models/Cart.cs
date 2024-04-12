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
            audioShopDBContext.CartItems.Add(new CartItem
            {
                CartId = CartId,
                Product = product,
                Price = product.Price
            });

            audioShopDBContext.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            return audioShopDBContext.CartItems.Where(c => c.CartId == CartId).Include(s => s.Product).ToList();
        }
    }
}
