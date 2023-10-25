using System.Collections.Concurrent;
using Manero.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Manero.Context;

public class DataContext : IdentityDbContext<AppIdentityUser>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<ProductModelEntity> ProductModels { get; set; }
    public DbSet<UserAddressEntity> AppUserAddress { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<PromocodesEntity> Promocodes { get; set; }
    public DbSet<UserPromocodesEntity> UserPromocodes { get; set; }
    public DbSet<WishListEntity> WishLists { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CreditCardsEntity> CreditCards { get; set;}

    public DbSet<OrderDetailEntity> OrderDetail { get; set; }
    public DbSet<OrderEntity> OrderDetails { get; set; }
    public DbSet<OrderStatusEntity> OrderStatus { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet<ProductColorEntity> ProductColor { get; set; }
    public DbSet<ProductDetailEntity> ProductDetail { get; set; }
    public DbSet<ProductSizeEntity> ProductSize { get; set; }
    public DbSet<ProductTagEntity> ProductTag { get; set; }
    public DbSet<ProductWishListEntity> ProductWishList { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
   
}
