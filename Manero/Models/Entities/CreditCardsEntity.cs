using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(CardNumber))]
public class CreditCardsEntity
{
  
    public string CreditCardName { get; set; } = null!;
    public string CardNumber { get;set; } = null!;
    public string ExpireDate { get; set; } = null!;
    public string CVV { get; set; } = null!;

    public string UserId { get; set; } = null!;
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; }=null!;
}
