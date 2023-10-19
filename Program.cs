using Manero.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            //Add repositories 
            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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