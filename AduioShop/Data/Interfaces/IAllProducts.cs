using AudioShop.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AudioShop.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> getFavorite { get; }
        Product getObjectProduct(int productId);
    }
}
