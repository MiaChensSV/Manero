using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(SizeId))]

public class ProductSizeEntity
{
    public int SizeId { get; set; }
    public string SizeName { get; set; } = null!;
    public ICollection<ProductDetailEntity> Products { get; set;} = new HashSet<ProductDetailEntity>();   
}

