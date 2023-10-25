using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(WishlistId))]

public class WishListEntity
{
  

    public int WishlistId { get;set; }
    public string UserId { get; set; } = null!;
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; } = null!;
    public ICollection<ProductWishListEntity> Products { get; set; } = new HashSet<ProductWishListEntity>();

}
