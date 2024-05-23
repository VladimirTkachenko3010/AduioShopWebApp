using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AudioShop.Database
{
    public class CategoryRepository : IProductsCategory
    {
        private readonly AudioShopDBContext audioShopDBContext;
        public CategoryRepository(AudioShopDBContext audioShopDBContext)
        {
            this.audioShopDBContext = audioShopDBContext;
        }

        public IEnumerable<Category> AllCategories => audioShopDBContext.Category;

        public Category GetCategoryById(int id)
        {
            return audioShopDBContext.Category.Find(id);
        }
        public Category GetCategoryByProductType(string productType)
        {
            return audioShopDBContext.Category.FirstOrDefault(c => c.ProductType == productType);
        }


        public void AddCategory(Category category)
        {
            audioShopDBContext.Category.Add(category);
            audioShopDBContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            audioShopDBContext.Category.Update(category);
            audioShopDBContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                audioShopDBContext.Category.Remove(category);
                audioShopDBContext.SaveChanges();
            }
        }
    }
}
