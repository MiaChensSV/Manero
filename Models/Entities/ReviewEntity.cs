﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(UserId),nameof(ProductId))]

public class ReviewEntity
{
    public string UserId { get; set; } = null!;
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; } = null!;
    public int ProductId { get; set; } 
    [ForeignKey("ProductId")]
    public ProductEntity Product { get; set; } = null!;
    public string? ReviewText { get;set; }
    [Column(TypeName = "decimal(1,2)")]
    public decimal Rating { get; set; }

}
