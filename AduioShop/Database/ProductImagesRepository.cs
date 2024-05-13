using AudioShop.Data.Models;

namespace AudioShop.Database
{
    public class ProductImagesRepository
    {
        private readonly AudioShopDBContext audioShopDBContext;
        public ProductImagesRepository(AudioShopDBContext audioShopDBContext)
        {
            this.audioShopDBContext = audioShopDBContext;
        }

        public List<ProductImages> GetProductImagesByProductId(int productId)
        {
            return audioShopDBContext.ProductImages
                .Where(pi => pi.ProductId == productId)
                .ToList();
        }

        public void AddProductImages(ProductImages productImages)
        {
            audioShopDBContext.ProductImages.Add(productImages);
            audioShopDBContext.SaveChanges();
        }

        public void AddListProductImages(List<ProductImages> productImages)
        {
            foreach (ProductImages productImage in productImages)
            {
                audioShopDBContext.ProductImages.Add(productImage);
            }
            audioShopDBContext.SaveChanges();
        }

        public void UpdateProductImages(ProductImages productImages)
        {

            var existingImage = audioShopDBContext.ProductImages
                .FirstOrDefault(pi => pi.ProductId == productImages.ProductId);

            if (existingImage != null)
            {
                audioShopDBContext.ProductImages.Remove(existingImage);
                audioShopDBContext.SaveChanges();
            }
            audioShopDBContext.ProductImages.Add(productImages);
            //audioShopDBContext.ProductImages.Update(productImages);
            audioShopDBContext.SaveChanges();
        }

        public void DeleteProductImage(ProductImages productImages)
        {
            var productImage = audioShopDBContext.ProductImages
                .FirstOrDefault(pi => pi.ProductId == productImages.ProductId);

            if (productImage != null)
            {
                audioShopDBContext.ProductImages.Remove(productImage);
                audioShopDBContext.SaveChanges();
            }
        }

    }
}
