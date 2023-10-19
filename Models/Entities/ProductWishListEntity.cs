using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(ProductId), nameof(WishListId))]

public class ProductWishListEntity
{
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int WishListId { get; set;}
    public WishListEntity WishList { get; set; } = null!;
}
