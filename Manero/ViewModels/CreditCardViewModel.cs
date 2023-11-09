using Manero.Models.Entities;

namespace Manero.ViewModels
{
    public class CreditCardViewModel
    {
        public IEnumerable<CreditCardsEntity> CreditCards { get; set; } = new List<CreditCardsEntity>();
    }
}
