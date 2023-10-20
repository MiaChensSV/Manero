namespace Manero.Models.Entities;

public class ProductColorEntity
{
    public int ColorId { get; set; }
    public string ColorName { get; set; } = null!;
    public ICollection<ProductDetailEntity> Products { get; set; }= new HashSet<ProductDetailEntity>();
}

