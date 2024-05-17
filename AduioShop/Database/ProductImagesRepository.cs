using AudioShop.Data.Models;
using Microsoft.CodeAnalysis;

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
            audioShopDBContext.ProductImages.AddRange(productImages);
            audioShopDBContext.SaveChanges();
        }

        public void UpdateProductImages(Product product, List<ProductImages> productImages)
        {
            if (productImages == null || !productImages.Any()) return;

            var productId = productImages.First().ProductId;
            var existingImages = audioShopDBContext.ProductImages
                .Where(pi => pi.ProductId == productId)
                .ToList();

            // Приводим пути к единому формату
            var existingImageUrls = existingImages.Select(img => img.ImageUrls.Replace("\\", "/")).ToList();
            var newImageUrls = productImages.Select(img => img.ImageUrls.Replace("\\", "/")).ToList();

            // Удаляем из product.ImageUrls старые изображения, которые не содержатся в новом списке
            product.ImageUrls.RemoveAll(img => !newImageUrls.Contains(img.ImageUrls));

            // Удаляем только те изображения, которые отсутствуют в новом списке
            var imagesToRemove = existingImages.Where(img => !newImageUrls.Contains(img.ImageUrls)).ToList();
            audioShopDBContext.ProductImages.RemoveRange(imagesToRemove);


            // Добавляем новые изображения
            var imagesToAdd = productImages.Where(img => !existingImageUrls.Contains(img.ImageUrls)).ToList();
            audioShopDBContext.ProductImages.AddRange(imagesToAdd);

            audioShopDBContext.SaveChanges();
        }

        public void DeleteProductImage(ProductImages productImage)
        {
            var existingImage = audioShopDBContext.ProductImages
            .FirstOrDefault(pi => pi.ProductId == productImage.ProductId && pi.Name == productImage.Name);
            if (existingImage != null)
            {
                audioShopDBContext.ProductImages.Remove(existingImage);
                audioShopDBContext.SaveChanges();
            }
        }

        public void DeleteProductImages(List<ProductImages> productImages)
        {
            audioShopDBContext.ProductImages.RemoveRange(productImages);
            audioShopDBContext.SaveChanges();
        }

    }
}
