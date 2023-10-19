using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class WishListEntity
{
    public int WishlistId { get;set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; } = null!;
    public ICollection<ProductWishListEntity> Products { get; set; } = new HashSet<ProductWishListEntity>();

}
