using AduioShop.Data.Interfaces;
using AduioShop.Data.Models;
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
    }
}
