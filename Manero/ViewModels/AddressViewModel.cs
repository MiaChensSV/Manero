using Manero.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Manero.ViewModels
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        public string StreetName { get; set; } = null!;

        [Required(ErrorMessage = "This field is required")]
        public string PostalCode { get; set; } = null!;
        [Required(ErrorMessage = "This field is required")]
        public string City { get; set; } = null!;
        [Required(ErrorMessage = "This field is required")]
        public string Country { get; set; } = null!;

        public static implicit operator AddressEntity(AddressViewModel model)
        {
            return new AddressEntity
            {
                StreetName = model.StreetName,
                PostalCode = model.PostalCode,
                City = model.City,
                Country = model.Country,
            };
        }
    }
}
