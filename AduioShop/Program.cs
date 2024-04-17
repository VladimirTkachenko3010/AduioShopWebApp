using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;
using AudioShop.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AudioShop
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
            // Добавление возможности чтения конфигурации из файла dbsettings.json
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = configBuilder.Build();

            // Использование конфигурации для получения строки подключения
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

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AudioShopDBContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6; // минимальное количество знаков в пароле
                options.Lockout.MaxFailedAccessAttempts = 10; // количество попыток о блокировки
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                // конфигурация Cookie с целью использования их для хранения авторизации
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(2); // Устанавливаем время жизни куки на 2 часа
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
            });


            services.AddMemoryCache();
            services.AddSession();

        }

        private static void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
            name: "categoryFilter",
            pattern: "Product/{action}/{category?}",
            defaults: new { controller = "Product", action = "Catalog" });
            });


            using (var scope = app.ApplicationServices.CreateScope())
            {
                AudioShopDBContext context = scope.ServiceProvider.GetRequiredService<AudioShopDBContext>();
                DBObjects.Initial(context);
            }
        }
    }
}
