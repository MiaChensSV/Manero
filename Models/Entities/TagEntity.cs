namespace Manero.Models.Entities;

public class TagEntity
{
    public int TagId { get;set; }
    public string TagName { get; set; } = null!;
    public ICollection<ProductTagEntity> Products { get; set; }=new HashSet<ProductTagEntity>();
}
