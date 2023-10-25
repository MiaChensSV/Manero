using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(StatusId))]
public class OrderStatusEntity
{
    public int StatusId { get; set; }
    public string StatusName { get; set; } = null!;
}

