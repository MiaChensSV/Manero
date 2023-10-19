using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(UserId), nameof(AddressId))]


public class UserAddressEntity
{
    public int UserId { get; set; }
    public AppIdentityUser AppIdentityUser { get; set; } = null!;
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; }=null!;
}
