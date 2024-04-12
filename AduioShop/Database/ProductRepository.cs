using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AudioShop.Database
{
    public class ProductRepository : IAllProducts
    {

        private readonly AudioShopDBContext audioShopDBContext;
        public ProductRepository(AudioShopDBContext audioShopDBContext)
        {
            this.audioShopDBContext = audioShopDBContext;
        }

        public IEnumerable<Product> Products => audioShopDBContext.Product.Include(c => c.Category);

        public IEnumerable<Product> getFavorite => audioShopDBContext.Product.Where(p => p.IsFavorite).Include(c => c.Category);

        public Product getObjectProduct(int productId) => audioShopDBContext.Product.FirstOrDefault(p => p.Id == productId);
    }
}
