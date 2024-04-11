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


            using (var scope = app.ApplicationServices.CreateScope())
            {
                AudioShopDBContext context = scope.ServiceProvider.GetRequiredService<AudioShopDBContext>();
                DBObjects.Initial(context);
            }
        }
    }
}
