using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;

[PrimaryKey(nameof(ArticleNumber))]
public class ProductDetailEntity
{
    private decimal _price = 0;
    private decimal _discountedprice = 0;

    public ProductDetailEntity()
    {
        Created_Date = DateTime.Now;
        Modified_Date = DateTime.Now;
        Deleted_Date= DateTime.Now;
    }
    public string ArticleNumber { get; set; } = null!;
    public int ProductId { get;set; } 
    [ForeignKey("ProductId")]
    public ProductEntity ProductModel { get; set; } = null!;

    public int SizeId { get;set; }
    [ForeignKey("SizeId")]
    public ProductSizeEntity Size { get; set; } = null!;

    public int ColorId { get;set; }
    [ForeignKey("ColorId")]
    public ProductColorEntity Color { get; set; } = null!;
    public string ProductTitle { get; set; } = null!;
    public string? ProductImageUrl { get; set; }

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
    public string? ProductDetailDescription { get; set; }
    public int Quantity { get;set; }
    public ICollection<ReviewEntity> Reviews { get; set; } = new HashSet<ReviewEntity>();

    public ICollection<ProductWishListEntity> Wishlists { get; set; } = new HashSet<ProductWishListEntity>();
    public ICollection<ProductTagEntity> Tags { get; set; } = new HashSet<ProductTagEntity>();

    public DateTime Created_Date{ get; set; }
    public DateTime Modified_Date { get; set; }
    public DateTime Deleted_Date { get; set; }
}

