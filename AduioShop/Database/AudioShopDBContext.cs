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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }

    }
}
