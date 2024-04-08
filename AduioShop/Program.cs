using AduioShop.Data.Interfaces;
using AduioShop.Data.Mocks;
using AudioShop.Database;
using Microsoft.EntityFrameworkCore;

namespace AduioShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Добавление сервисов
            ConfigureServices(builder.Services);

            var app = builder.Build();

            // Настройка HTTP-конвейера
            Configure(app);

            app.Run();
        }

        private static IConfiguration _conString;
        public Program(Microsoft.AspNetCore.Hosting.IWebHostEnvironment hosting)
        {
            _conString = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AudioShopDBContext>(options => options.UseSqlServer(_conString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllProducts, ProductRepository>();
            services.AddTransient<IProductsCategory, CategoryRepository>();
            services.AddControllersWithViews();
        }

        private static void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=Catalog}/{id?}");
            });
        }
    }
}
