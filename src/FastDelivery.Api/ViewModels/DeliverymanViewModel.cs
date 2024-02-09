using System.ComponentModel.DataAnnotations;

namespace FastDelivery.Api.ViewModels
{
    public class DeliverymanViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string AvatarId { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
