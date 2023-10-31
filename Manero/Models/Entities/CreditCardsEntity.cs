using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(CardNumber))]
public class CreditCardsEntity
{
  
    public string CreditCardName { get; set; } = null!;
    public int CardNumber { get;set; }
    public DateTime ExpireDate { get; set; }
    public int CVV { get; set; }

    public string UserId { get; set; } = null!;
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; }=null!;
}
