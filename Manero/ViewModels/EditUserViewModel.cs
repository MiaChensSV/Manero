using System.ComponentModel.DataAnnotations;

namespace Manero.ViewModels
{
    public class EditUserViewModel
    {

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
