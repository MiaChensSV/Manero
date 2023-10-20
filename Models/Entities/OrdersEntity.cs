using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class OrderEntity
{
    public OrderEntity()
    {
        Created_Date = DateTime.Now;
        Modified_Date = DateTime.Now;
    }
    public int OrdersId { get; set; }   
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; } = null!;
    public int StatusId { get; set; }
    [ForeignKey("StatusId")]
    public OrderStatusEntity StatusName { get; set; } = null!;
    public int PromocodeId { get; set; }
    public PromocodesEntity Promocode { get; set; } = null!;

    public string ShippingAddress { get; set; } = null!;
    public ICollection<OrderDetailEntity> OrderDetailItems { get; set; }=new HashSet<OrderDetailEntity>();

    [Column(TypeName = "money")]
    public decimal DeliveryFee { get; set; }

    [Column(TypeName = "money")]
    public decimal Totalcost { get;set; }
    public string? TrackingNumber { get;set; }
    public DateTime Created_Date { get; set; }
    public DateTime Modified_Date { get; set; }
}
