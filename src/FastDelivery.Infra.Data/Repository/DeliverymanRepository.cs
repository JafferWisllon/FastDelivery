using FastDelivery.Business;

namespace FastDelivery.Infra.Data.Repository
{
    public class DeliverymanRepository : Repository<Deliveryman>, IDeliverymanRepository
    {
        public DeliverymanRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
