using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(OrderItemId))]
public class OrderDetailEntity
{
    public OrderDetailEntity()
    {
        Created_Date = DateTime.Now;
        Modified_Date = DateTime.Now;
        Deleted_Date = DateTime.Now;
    }

    public int OrderItemId { get; set; }
    public int OrderId { get;set; }
    [ForeignKey("OrderId")]
    public OrderEntity Order { get; set; } = null!;

    public string ArticleNumber { get; set; } = null!; 
    [ForeignKey("ArticleNumber")]

	public ProductDetailEntity Product { get; set; }=null!;
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(7,2)")]
    public decimal Price { get; set; }


    [Column(TypeName = "decimal(7,2)")]
    [Display(Name = "Sales Price")]
    public decimal DiscountedPrice { get; set; }
 
    public DateTime Created_Date { get; set; }
    public DateTime Modified_Date { get; set; }
    public DateTime Deleted_Date { get; set; }
}

