using Manero.Context;
using Manero.Models.Entities;
using Manero.Models.Repository;
using Manero.Repository;
using Manero.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            //Add repositories 

            builder.Services.AddScoped<AddressRepository>();
            builder.Services.AddScoped<UserAddressRepository>();
            builder.Services.AddScoped<CreditCardRepository>();

            builder.Services.AddDbContext<DataContext>(x => x.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

            //test i localdb
            //builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("sql")));
            builder.Services.AddIdentity<AppIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            //Repositories
            builder.Services.AddScoped<ProductListRepo>();
            builder.Services.AddScoped<ReviewProductListRepo>();
            builder.Services.AddScoped<ShopByTagsRepo>();


            //Services
            builder.Services.AddScoped<ProductListService>();

            var app = builder.Build();


            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Onboarding}/{action=Index}/{id?}");

            app.Run();
        }
    }
}