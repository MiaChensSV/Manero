using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;

public class AppIdentityUser:IdentityUser
{
    public int UserId { get; set; }

    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }

    [ProtectedPersonalData]
    public string? ProfileImageUrl { get; set; }

    public int WishlistId { get; set; }
    [ForeignKey("WishlistId")]
    public WishListEntity? Wishlist { get; set; }
    public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();
    public ICollection<CreditCardsEntity> CreditCards { get; set; } = new HashSet<CreditCardsEntity>();
    public ICollection<UserPromocodesEntity> Promocodes { get; set; } = new HashSet<UserPromocodesEntity>();  
    public ICollection<ReviewEntity> Reviews { get; set; } = new HashSet<ReviewEntity>();
}
public class ProductEntity
{
    public int ProductId { get;set; }
    public string ModelNumber { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public ICollection<ProductDetailEntity> Products { get; set; } = new HashSet<ProductDetailEntity>();
    public ICollection<ProductCategoryEntity> Categories { get; set; } = new HashSet<ProductCategoryEntity>();

}

[PrimaryKey(nameof(ArticleNumber))]
public class ProductDetailEntity
{
    private decimal _price = 0;
    private decimal _discountedprice = 0;

    public ProductDetailEntity()
    {
        Created_Date = DateTime.Now;
        Modified_Date = DateTime.Now;
        Deleted_Date= DateTime.Now;
    }
    public string ArticleNumber { get; set; } = null!;
    public string ModelNumber { get;set; } = null!;
    [ForeignKey("ModelNumber")]
    public ProductEntity ProductModel { get; set; } = null!;

    public int SizeId { get;set; }
    [ForeignKey("SizeId")]
    public ProductSizeEntity Size { get; set; } = null!;

    public int ColorId { get;set; }
    [ForeignKey("ColorId")]
    public ProductColorEntity Color { get; set; } = null!;
    public string ProductTitle { get; set; } = null!;
    public string? ProductImageUrl { get; set; }

    [Column(TypeName = "money")]
    public decimal Price
    {
        get { return _price; }
        set { _price = Math.Round(value, 2); }
    }

    [Column(TypeName = "money")]
    [Display(Name = "Sales Price")]
    public decimal DiscountedPrice
    {
        get { return _discountedprice; }
        set { _price = Math.Round(value, 2); }
    }

    public int Quantity { get;set; }
    public ICollection<ReviewEntity> Reviews { get; set; } = new HashSet<ReviewEntity>();

    public ICollection<ProductWishListEntity> Wishlists { get; set; } = new HashSet<ProductWishListEntity>();
    public ICollection<ProductTagEntity> Tags { get; set; } = new HashSet<ProductTagEntity>();

    public DateTime Created_Date{ get; set; }
    public DateTime Modified_Date { get; set; }
    public DateTime Deleted_Date { get; set; }
}


public class ProductColorEntity
{
    public int ColorId { get; set; }
    public string ColorName { get; set; } = null!;
    public ICollection<ProductDetailEntity> Products { get; set; }= new HashSet<ProductDetailEntity>();
}


public class ProductSizeEntity
{
    public int SizeId { get; set; }
    public string SizeName { get; set; } = null!;
    public ICollection<ProductDetailEntity> Products { get; set;} = new HashSet<ProductDetailEntity>();   
}


public class OrderStatusEntity
{
    public int StatusId { get; set; }
    public string StatusName { get; set; } = null!;
}
public class OrderDetailEntity
{
    public OrderDetailEntity()
    {
        Created_Date = DateTime.Now;
        Modified_Date = DateTime.Now;
        Deleted_Date = DateTime.Now;
    }
    private decimal _price = 0;
    private decimal _discountedprice = 0;
    public int OrderItemId { get; set; }
    public int OrderId { get;set; }
    [ForeignKey("OrderID")]
    public OrderEntity Order { get; set; } = null!;
    public string ArticleNumber { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price
    {
        get { return _price; }
        set { _price = Math.Round(value, 2); }
    }

    [Column(TypeName = "money")]
    [Display(Name = "Sales Price")]
    public decimal DiscountedPrice
    {
        get { return _discountedprice; }
        set { _price = Math.Round(value, 2); }
    }
    public DateTime Created_Date { get; set; }
    public DateTime Modified_Date { get; set; }
    public DateTime Deleted_Date { get; set; }
}

