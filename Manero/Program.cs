namespace Manero
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<AddressService>();
            builder.Services.AddScoped<CreditCardService>();
            builder.Services.AddScoped<ShoppingCartService>();
            builder.Services.AddScoped<UserService>();

            builder.Services.AddScoped<CheckOutService>();
            builder.Services.AddScoped<ProductDetailsService>();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            builder.Services.AddHttpContextAccessor();
            //Add repositories 
            builder.Services.AddScoped<PromoCodeRepo>();
            builder.Services.AddScoped<CheckOutRepository>();
            builder.Services.AddScoped<ProductDetailsRepo>();
            builder.Services.AddScoped<AddressRepository>();
            builder.Services.AddScoped<UserAddressRepository>();
            builder.Services.AddScoped<CreditCardRepository>();
            builder.Services.AddScoped<ShoppingCartRepository>();

            builder.Services.AddDbContext<DataContext>(x => x.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

            //test i localdb
            //builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("sql")));
            builder.Services.AddIdentity<AppIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            //Repositories
            builder.Services.AddScoped<ProductListRepo>();
            builder.Services.AddScoped<ShopByTagsRepo>();


            //Services
            builder.Services.AddScoped<IProductListService, ProductListService>();

            var app = builder.Build();


            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Onboarding}/{action=Index}/{id?}");

            app.Run();
        }
    }
}