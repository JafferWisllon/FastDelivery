using FluentValidation;

namespace FastDelivery.Business
{
    public class DeliverymanValidation : AbstractValidator<Deliveryman>
    {
        public DeliverymanValidation()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Nome do entregador é obrigatório")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(d => d.Email)
                .NotEmpty().WithMessage("Email do entregador é obrigatório")
                .EmailAddress().WithMessage("O campo {PropertyName} precisa ser um e-mail válido");

            RuleFor(d => d.AvatarId)
                .NotEmpty().WithMessage("Campo avatar é obrigatório");
        }
    }
}
