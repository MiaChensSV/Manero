using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(OrderId))]

public class OrderEntity
{
    public OrderEntity()
    {
        Created_Date = DateTime.Now;
        Modified_Date = DateTime.Now;
    }
    public int OrderId { get; set; }   
    public string UserId { get; set; } = null!;
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; } = null!;
    public int StatusId { get; set; }
    [ForeignKey("StatusId")]
    public OrderStatusEntity StatusName { get; set; } = null!;
    public int PromocodeId { get; set; }
    public PromocodesEntity Promocode { get; set; } = null!;

    public string ShippingAddress { get; set; } = null!;
    public ICollection<OrderDetailEntity> OrderDetailItems { get; set; }=new HashSet<OrderDetailEntity>();

    [Column(TypeName = "decimal(7,2)")]
    public decimal DeliveryFee { get; set; }

    [Column(TypeName = "decimal(7,2)")]
    public decimal TotalCost { get;set; }
    public string? TrackingNumber { get;set; }
    public DateTime Created_Date { get; set; }
    public DateTime Modified_Date { get; set; }
}
