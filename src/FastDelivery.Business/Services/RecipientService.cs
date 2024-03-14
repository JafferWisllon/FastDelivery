namespace FastDelivery.Business
{
    public class RecipientService : BaseService, IRecipientService
    {
        private readonly IRecipientRepository _recipientRepository;

        public RecipientService(
            IRecipientRepository recipientRepository,
            INotifier notifier) : base(notifier)
        {
            _recipientRepository = recipientRepository;
        }

        public async Task Add(Recipient recipient)
        {
            if (!Validate(new RecipientValidation(), recipient)) return;

            await _recipientRepository.Add(recipient);
        }

        public async Task Update(Recipient recipient)
        {
            if (!Validate(new RecipientValidation(), recipient)) return;

            await _recipientRepository.Update(recipient);
        }

        public async Task Remove(Guid id)
        {
            var recipient = await _recipientRepository.GetById(id);
            if (recipient == null)
            {
                Notify("Destinatário não existe");
                return;
            }
            await _recipientRepository.Delete(id);
        }

        public void Dispose()
        {
            _recipientRepository?.Dispose();
        }
    }
}
