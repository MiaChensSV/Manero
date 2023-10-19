using Manero.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Manero.Context;

public class DataContext : IdentityDbContext<AppIdentityUser>
{
    public DataContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ProductColorEntity>().HasKey(fk=>new {fk.ProductId,fk.ColorId});
    }
}
