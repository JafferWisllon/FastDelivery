namespace FastDelivery.Business
{
    public interface IDeliverymanService : IDisposable
    {
        Task Add(Deliveryman deliveryman);
        Task Update(Deliveryman deliveryman);
        Task Remove(Guid id);
    }
}
