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
    private decimal _price = 0;
    private decimal _discountedprice = 0;
    public int OrderItemId { get; set; }
    public int OrderId { get;set; }
    [ForeignKey("OrderID")]
    public OrderEntity Order { get; set; } = null!;
    [ForeignKey("ArticleNumber")]
    public string ArticleNumber { get; set; } = null!;
    public ProductDetailEntity Product { get; set; }=null!;
    public int Quantity { get; set; }
    [Column(TypeName = "money")]
    public decimal Price
    {
        get { return _price; }
        set { _price = Math.Round(value, 2); }
    }

    [Column(TypeName = "money")]
    [Display(Name = "Sales Price")]
    public decimal DiscountedPrice
    {
        get { return _discountedprice; }
        set { _price = Math.Round(value, 2); }
    }
    public DateTime Created_Date { get; set; }
    public DateTime Modified_Date { get; set; }
    public DateTime Deleted_Date { get; set; }
}

