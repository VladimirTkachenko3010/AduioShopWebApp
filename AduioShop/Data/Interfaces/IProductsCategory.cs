using AduioShop.Data.Models;

namespace AduioShop.Data.Interfaces
{
    public interface IProductsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
