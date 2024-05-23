using AudioShop.Data.Models;

namespace AudioShop.Data.Interfaces
{
    public interface IProductsCategory
    {
        IEnumerable<Category> AllCategories { get; }
        Category GetCategoryById(int id);
        Category GetCategoryByProductType(string ProductType);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
