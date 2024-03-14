using FastDelivery.Business;

namespace FastDelivery.Infra.Data.Repository
{
    public class RecipientRepository : Repository<Recipient>, IRecipientRepository
    {
        public RecipientRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
