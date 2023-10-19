using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

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
    public ICollection<UserAddressEntity> Addresses { get; set; }=new HashSet<UserAddressEntity>();
    public ICollection<CreditCardsEntity> CreditCards { get; set; }=new HashSet<CreditCardsEntity>();
    public ICollection<UserPromocodesEntity> Promocodes { get; set; }=new HashSet<UserPromocodesEntity>();  
    public ICollection<ReviewEntity> Reviews { get; set; } = new HashSet<ReviewEntity>();
}

public class ReviewEntity
{
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; } = null!;
    public int ProductId { get;set; }
    [ForeignKey("ProductId")]
    public ProductEntity Product { get; set; } = null!;
    public string? ReviewText { get;set; }
    public decimal Rating { get; set; }

}

public class ProductEntity
{
    private decimal _price = 0;
    private decimal _discountedprice = 0;

    public ProductEntity()
    {
        Created_Date = DateTime.Now;
        Modified_Date = DateTime.Now;
        Deleted_Date= DateTime.Now;
    }

    public int ProductId { get; set; }
    public string ProductTitle { get; set; } = null!;
    public string ProductDescription { get; set; }= null!;
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

    public int Quantity { get; set; }
    public ICollection<ProductCategoryEntity> Categories { get; set; }=new HashSet<ProductCategoryEntity>();    
    public ICollection<ReviewEntity> Reviews { get; set; } = new HashSet<ReviewEntity>();

    public ICollection<ProductWishListEntity> Wishlists { get; set; }=new HashSet<ProductWishListEntity>();
    public ICollection<ProductTagEntity> Tags { get; set; } = new HashSet<ProductTagEntity>();
    /*
    public ICollection<ProductColorEntity> Colors { get; set; }
    public ICollection<ProductSizeEntity> Sizes { get; set; }
    */
    public DateTime Created_Date{ get; set; }
    public DateTime Modified_Date { get; set; }
    public DateTime Deleted_Date { get; set; }

}

public class OrderStatusEntity
{
    public int StatusId { get;set; }
    public string StatusName { get; set; } = null!;
}
public class OrderDetailEntity
{
     
}
public class ProductColorEntity
{
    public int ColorId { get; set; }
    public ColorEnttiy Color { get; set; } = null!;
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; }=null!;
}

public class ColorEnttiy
{
    public int ColorId { get;set; }
    public string ColorName { get; set; } = null!;
    public ICollection<ProductColorEntity> Products { get; set; }=new HashSet<ProductColorEntity>();
}
public class ProductSizeEntity
{
    public int SizeId { get; set; }
    public SizeEntity Size { get; set; } = null!;
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
}
public class SizeEntity
{
    public int SizeId { get; set; }
    public string SizeName { get; set; }=null!;
}
public class InventoryEntity
{
    public InventoryEntity()
    {
        Created_Date = DateTime.Now;
        Modified_Date = DateTime.Now;
        Deleted_Date=DateTime.Now;
    }
    public int ProductId { get; set; }
    public int ColorId { get; set;}
    public int SizeId { get; set; }
    public int Quantity { get;set; }
    public DateTime Created_Date { get; set; }
    public DateTime Modified_Date { get; set; }
    public DateTime Deleted_Date { get; set; }
}