using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(CategoryId))]
public class CategoryEntity
{
    
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public ICollection<ProductCategoryEntity>  Products { get; set; }= new HashSet<ProductCategoryEntity>();    
}
