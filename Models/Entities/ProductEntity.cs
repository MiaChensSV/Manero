using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(ProductId))]

public class ProductEntity
{
    public int ProductId { get;set; }
    public string ModelNumber { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public ICollection<ProductDetailEntity> Products { get; set; } = new HashSet<ProductDetailEntity>();
    public ICollection<ProductCategoryEntity> Categories { get; set; } = new HashSet<ProductCategoryEntity>();

}

