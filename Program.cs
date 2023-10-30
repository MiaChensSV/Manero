using Manero.Context;
using Microsoft.EntityFrameworkCore;
using Manero.Models.Repository;

namespace Manero
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<AddressRepository>();
            //Add repositories 

            builder.Services.AddDbContext<DataContext>(x => x.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
           
            //test i localdb
            //builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("sql")));

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