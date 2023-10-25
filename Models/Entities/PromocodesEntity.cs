using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(PromocodeId))]

public class PromocodesEntity
{
    public int PromocodeId { get; set; }
    public string PromocodeTitle { get;set; } = null!;
    public string PromocodeDescription { get;set; } = null!;
    [Column(TypeName = "decimal(18,2)")]
    public decimal PromocodePercentage { get; set; }
    public ICollection<UserPromocodesEntity> Users { get; set; }= new HashSet<UserPromocodesEntity>();  
}
