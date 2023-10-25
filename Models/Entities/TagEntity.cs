using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(TagId))]

public class TagEntity
{
    public int TagId { get;set; }
    public string TagName { get; set; } = null!;
    public ICollection<ProductTagEntity> Products { get; set; }=new HashSet<ProductTagEntity>();
}
