using Manero.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Manero.ViewModels
{
    public class AddCreditCardViewModel
    {
        [Required(ErrorMessage ="This field is requeird")]
        public string CreditCardName { get; set; } = null!;
        
        [Required(ErrorMessage = "This field is requeird")]
        public string CardNumber { get; set; } = null!;
        
        [Required(ErrorMessage = "This field is requeird")]
        public string ExpireDate { get; set; } = null!;
        
        [Required(ErrorMessage = "This field is requeird")]
        public string CVV { get; set; } = null!;

        public static implicit operator CreditCardsEntity(AddCreditCardViewModel model)
        {
            return new CreditCardsEntity
            {
                CreditCardName = model.CreditCardName,
                CardNumber = model.CardNumber,
                ExpireDate = model.ExpireDate,
                CVV = model.CVV 
            };
        }
    }

   
}
