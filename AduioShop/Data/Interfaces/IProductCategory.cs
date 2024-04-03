using AduioShop.Data.Models;

namespace AduioShop.Data.Interfaces
{
    public interface IProductCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
