using System.ComponentModel.DataAnnotations;

namespace FastDelivery.Api.Models
{
    public class Deliveryman
    {
        public Deliveryman(string name, string avatarId, string email)
        {
            Name = name;
            AvatarId = avatarId;
            Email = email;
            CreatedAt = DateTime.UtcNow;
            UppdatedAt = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UppdatedAt { get; set; }
    }
}
