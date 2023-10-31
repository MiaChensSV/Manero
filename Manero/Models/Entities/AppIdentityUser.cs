using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Manero.Models.Entities;

public class AppIdentityUser:IdentityUser
{
    public AppIdentityUser()
    {
        Created_At=DateTime.Now;
        Modified_At=DateTime.Now;
        Deleted_At=DateTime.Now;
    }

    [Required]
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [Required]
    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }

    [ProtectedPersonalData]
    public string? ProfileImageUrl { get; set; }

    public DateTime Created_At { get; set; }
    public DateTime Modified_At { get; set; }
    public DateTime Deleted_At { get; set; }

    public WishListEntity? Wishlist { get; set; }
    public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();
    public ICollection<CreditCardsEntity> CreditCards { get; set; } = new HashSet<CreditCardsEntity>();
    public ICollection<UserPromocodesEntity> Promocodes { get; set; } = new HashSet<UserPromocodesEntity>();  
    public ICollection<ReviewEntity> Reviews { get; set; } = new HashSet<ReviewEntity>();
}

