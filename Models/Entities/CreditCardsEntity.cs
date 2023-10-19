using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(CardNumber),nameof(CreditCardName))]
public class CreditCardsEntity
{
    public string CreditCardName { get; set; } = null!;
    public int CardNumber { get;set; }
    public DateTime ExpiratationDate { get; set; }
    public int CVV { get; set; }    

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; }=null!;
}
