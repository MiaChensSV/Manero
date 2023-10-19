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
        //Deleted_Date=?
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

    
    public ICollection<ProductCategoryEntity> Categories { get; set; }=new HashSet<ProductCategoryEntity>();    
    public ICollection<ReviewEntity> Reviews { get; set; } = new HashSet<ReviewEntity>();

    public ICollection<ProductWishListEntity> Wishlists { get; set; }=new HashSet<ProductWishListEntity>();
    public ICollection<ProductTagEntity> Tags { get; set; } = new HashSet<ProductTagEntity>();
    public DateTime Created_Date{ get; set; }
    public DateTime Modified_Date { get; set; }
    public DateTime Deleted_Date { get; set; }

}

public class OrderStatusEntity
{
    public int StatusId { get;set; }
    public string StatusName { get; set; } = null!;
}
public class OrdersEntity
{
    public OrdersEntity()
    {
        Created_Date = DateTime.Now;
        Modified_Date = DateTime.Now;
    }
    public int OrdersId { get; set; }   
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; } = null!;
    public int StatusId { get; set; }
    [ForeignKey("StatusId")]
    public OrderStatusEntity StatusName { get; set; } = null!;
    public int PromocodeId { get; set; }
    public PromocodesEntity Promocode { get; set; } = null!;
    //shippingaddress connected to addressEntity?

    [Column(TypeName = "money")]
    public decimal DeliveryFee { get; set; }

    [Column(TypeName = "money")]
    public decimal Totalcost { get;set; }
    public string? TrackingNumber { get;set; }
    public DateTime Created_Date { get; set; }
    public DateTime Modified_Date { get; set; }
}
public class OrderDetailEntity
{
     
}