namespace FastDelivery.Business
{
    public class Deliveryman : Entity
    {
        public string? Name { get; set; }
        public string? AvatarId { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
    }
}
