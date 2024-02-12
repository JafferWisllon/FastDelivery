namespace FastDelivery.Business
{
    public interface IRecipientService : IDisposable
    {
        Task Add(Recipient recipient);
        Task Update(Recipient recipient);
        Task Remove(Guid id);
    }
}
