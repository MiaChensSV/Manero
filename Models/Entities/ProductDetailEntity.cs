using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;

[PrimaryKey(nameof(ArticleNumber))]
public class ProductDetailEntity
{

    public ProductDetailEntity()
    {
        Created_Date = DateTime.Now;
        Modified_Date = DateTime.Now;
        Deleted_Date = DateTime.Now;
    }
    public string ArticleNumber { get; set; } = null!;
    public int ProductId { get;set; } 
    [ForeignKey("ProductId")]
    public ProductModelEntity ProductModel { get; set; } = null!;

    public int SizeId { get;set; }
    [ForeignKey("SizeId")]
    public ProductSizeEntity Size { get; set; } = null!;

    public int ColorId { get;set; }
    [ForeignKey("ColorId")]
    public ProductColorEntity Color { get; set; } = null!;
    public string ProductTitle { get; set; } = null!;
    public string? ProductImageUrl { get; set; }
    [Column(TypeName = "decimal(7,2)")]
    public decimal Price{get; set; }
    [Column(TypeName = "decimal(7,2)")]
    [Display(Name = "Sales Price")]
    public decimal DiscountedPrice { get; set; }
 
    public string? ProductDetailDescription { get; set; }
    public int Quantity { get;set; }

    public ICollection<ProductWishListEntity> Wishlists { get; set; } = new HashSet<ProductWishListEntity>();


    public DateTime Created_Date{ get; set; }
    public DateTime Modified_Date { get; set; }
    public DateTime Deleted_Date { get; set; }
}

