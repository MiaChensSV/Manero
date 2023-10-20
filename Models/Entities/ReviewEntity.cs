using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class ReviewEntity
{
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; } = null!;
    public int ProductId { get;set; }
    [ForeignKey("ProductId")]
    public ProductEntity Product { get; set; } = null!;
    public string? ReviewText { get;set; }
    public decimal Rating { get; set; }

}
