using AduioShop.Data.Interfaces;
using AduioShop.Data.Mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAllProducts, MockProducts>();
            services.AddTransient<IProductsCategory, MockCategory>();
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
