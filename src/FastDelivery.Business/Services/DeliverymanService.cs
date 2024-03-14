
namespace FastDelivery.Business
{
    public class DeliverymanService : BaseService, IDeliverymanService
    {
        private readonly IDeliverymanRepository _deliverymanRepository;

        public DeliverymanService(
            IDeliverymanRepository deliverymanRepository,
            INotifier notifier) : base(notifier)
        {
            _deliverymanRepository = deliverymanRepository;
        }

        public async Task Add(Deliveryman deliveryman)
        {
            if (!Validate(new DeliverymanValidation(), deliveryman)) return;

            if (_deliverymanRepository.Get(d => d.Email == deliveryman.Email).Result.Any())
            {
                Notify("Já existe entegragor com esse email cadastrado");
                return;
            }

            await _deliverymanRepository.Add(deliveryman);
        }

        public async Task Update(Deliveryman deliveryman)
        {
            if (!Validate(new DeliverymanValidation(), deliveryman)) return;

            if (_deliverymanRepository.Get(d => d.Email == deliveryman.Email && d.Id != deliveryman.Id).Result.Any())
            {
                Notify("Já existe entegragor com esse email cadastrado");
                return;
            }

            await _deliverymanRepository.Update(deliveryman);
        }

        public async Task Remove(Guid id)
        {
            var deliveryman = await _deliverymanRepository.GetById(id);
            if (deliveryman is null)
            {
                Notify("Entregador não existe");
            }
            await _deliverymanRepository.Delete(id);
        }

        public void Dispose()
        {
            _deliverymanRepository?.Dispose();
        }
    }
}
