using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class CreditCardsEntity
{
    public int CreditCardId { get; set; }
    public string CreditCardName { get; set; } = null!;
    public int CardNumber { get;set; }
    public DateTime ExpiratationDate { get; set; }
    public int CVV { get; set; }    

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public AppIdentityUser User { get; set; }=null!;
}
