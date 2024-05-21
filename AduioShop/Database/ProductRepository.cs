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

        public IEnumerable<Product> SearchProducts(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return Products;
            }
            return Products.Where(e => e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                                     || e.Brand.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public Product getObjectProduct(int productId) => audioShopDBContext.Product.FirstOrDefault(p => p.Id == productId);

        public async Task<Product> getObjectProductAsync(int productId) =>
    await audioShopDBContext.Product.FirstOrDefaultAsync(p => p.Id == productId);
        public void AddProduct(Product product)
        {
            audioShopDBContext.Product.Add(product);
            audioShopDBContext.SaveChanges();
        }



        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await audioShopDBContext.Product.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                audioShopDBContext.Entry(existingProduct).CurrentValues.SetValues(product);

                await audioShopDBContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        public async Task DeleteProductAsync(Product productToDelete)
        {
            audioShopDBContext.Product.Remove(productToDelete);
            await audioShopDBContext.SaveChangesAsync();
        }
    }
}

