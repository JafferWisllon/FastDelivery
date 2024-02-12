namespace FastDelivery.Business
{
    public class Recipient : Entity
    {
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
    }
}
