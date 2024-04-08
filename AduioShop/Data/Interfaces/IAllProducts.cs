using AduioShop.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AduioShop.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> getFavorite { get; }
        Product getObjectProduct(int productId);
    }
}
