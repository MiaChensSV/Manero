using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(UserId), nameof(PromocodeId))]

public class UserPromocodesEntity
{
    public string UserId { get; set; } = null!;
    public AppIdentityUser User { get; set; }=null!;
    public int PromocodeId { get; set; }
    public PromocodesEntity Promocode { get; set; } = null!;
}