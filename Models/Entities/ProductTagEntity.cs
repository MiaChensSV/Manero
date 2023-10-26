using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(ProductId), nameof(TagId))]
public class ProductTagEntity
{
    public int ProductId { get;set; }
    public ProductModelEntity Product { get; set; } = null!;
    public int TagId { get; set; }
    public TagEntity Tag { get; set; } = null!;
}