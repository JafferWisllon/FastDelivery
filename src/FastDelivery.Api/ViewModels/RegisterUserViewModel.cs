using System.ComponentModel.DataAnnotations;

namespace FastDelivery.Api.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}
