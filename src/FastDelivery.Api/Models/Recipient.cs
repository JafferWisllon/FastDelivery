using System.ComponentModel.DataAnnotations;

namespace FastDelivery.Api.Models
{
    public class Recipient
    {
        public Recipient(string name, string street, string number, string complement, string state, string city, string zipCode)
        {
            Name = name;
            Street = street;
            Number = number;
            Complement = complement;
            State = state;
            City = city;
            ZipCode = zipCode;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }

        [MaxLength(4)]
        public string Number { get; set; }
        public string Complement { get; set; }

        [MaxLength(2)]
        public string State { get; set; }
        public string City { get; set; }

        [MaxLength(8)]
        public string ZipCode { get; set; }
    }
}
