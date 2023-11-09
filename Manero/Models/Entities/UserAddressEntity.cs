using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(UserId), nameof(AddressId))]


public class UserAddressEntity
{
    public string UserId { get; set; } = null!;
    public AppIdentityUser AppIdentityUser { get; set; } = null!;
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;
    public string? LocationName { get; set; }
}
