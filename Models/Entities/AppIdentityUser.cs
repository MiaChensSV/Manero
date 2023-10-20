using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
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
    public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();
    public ICollection<CreditCardsEntity> CreditCards { get; set; } = new HashSet<CreditCardsEntity>();
    public ICollection<UserPromocodesEntity> Promocodes { get; set; } = new HashSet<UserPromocodesEntity>();  
    public ICollection<ReviewEntity> Reviews { get; set; } = new HashSet<ReviewEntity>();
}

