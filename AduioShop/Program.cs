using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;
using AudioShop.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AudioShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ���������� ��������
            ConfigureServices(builder.Services);

            var app = builder.Build();

            // ��������� HTTP-���������
            Configure(app);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // ���������� ����������� ������ ������������ �� ����� dbsettings.json
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = configBuilder.Build();

            // ������������� ������������ ��� ��������� ������ �����������
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AudioShopDBContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IAllProducts, ProductRepository>();
            services.AddTransient<IProductsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddControllersWithViews();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => Cart.GetCart(sp));


            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

        }

        private static void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();


            app.UseRouting();
            //app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(name: "default", template: "{controller =Home}/{action =Index}/{id?}");
            //    routes.MapRoute(name: "categoryFilter", template: "Product/{action}/{category?}", defaults: new { Controller = "Product", action = "Catalog" });
            //});

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
            name: "categoryFilter",
            pattern: "Product/{action}/{category?}",
            defaults: new { controller = "Product", action = "Catalog" });

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Products}/{action=Catalog}/{id?}");
            });


            using (var scope = app.ApplicationServices.CreateScope())
            {
                AudioShopDBContext context = scope.ServiceProvider.GetRequiredService<AudioShopDBContext>();
                DBObjects.Initial(context);
            }
        }
    }
}
