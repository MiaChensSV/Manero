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
public class WishListEntity
{
    public int WishlistId { get;set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; } = null!;
    public ICollection<ProductWishListEntity> Products { get; set; } = new HashSet<ProductWishListEntity>();

}
public class ProductWishListEntity
{
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int WishListId { get; set;}
    public WishListEntity WishList { get; set; } = null!;
}

public class ProductEntity
{
    public ICollection<ReviewEntity> Reviews { get; set; } = new HashSet<ReviewEntity>();

    public ICollection<ProductWishListEntity> Wishlists { get; set; }=new HashSet<ProductWishListEntity>();
}