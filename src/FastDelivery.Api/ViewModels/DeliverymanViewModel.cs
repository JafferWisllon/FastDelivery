using System.ComponentModel.DataAnnotations;

namespace FastDelivery.Api
{
    public class DeliverymanViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string AvatarId { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
