using System.ComponentModel.DataAnnotations;

namespace FastDelivery.Api.ViewModels
{
    public class RecipientViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Street { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(4)]
        public string Number { get; set; }

        public string Complement { get; set; }

        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        [MaxLength(255)]
        public string City { get; set; }

        [Required]
        [MaxLength(8)]
        public string ZipCode { get; set; }
    }
}
