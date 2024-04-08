using AduioShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AudioShop.Database
{
    public class AudioShopDBContext : DbContext
    {
        public AudioShopDBContext(DbContextOptions<AudioShopDBContext> options) : base(options)
        {

        }


        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
