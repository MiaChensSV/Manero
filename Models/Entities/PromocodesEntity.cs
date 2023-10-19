namespace Manero.Models.Entities;

public class PromocodesEntity
{
    public int PromocodeId { get; set; }
    public string PromocodeTitle { get;set; } = null!;
    public string PromocodeDescription { get;set; } = null!;
    public decimal PromocodePercentage { get; set; }
    public ICollection<UserPromocodesEntity> Users { get; set; }= new HashSet<UserPromocodesEntity>();  
}
