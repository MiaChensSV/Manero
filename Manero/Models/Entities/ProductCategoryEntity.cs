using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(ProductId),nameof(CategoryId))]
public class ProductCategoryEntity
{
    public int ProductId { get; set; }
    public ProductModelEntity Product { get; set; } = null!;
    public int CategoryId { get; set; } 
    public CategoryEntity Category { get; set; } = null!;
}