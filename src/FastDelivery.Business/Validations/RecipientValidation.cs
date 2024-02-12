using FluentValidation;

namespace FastDelivery.Business
{
    public class RecipientValidation : AbstractValidator<Recipient>
    {
        public RecipientValidation()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Nome do endereço é obrigatório")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(r => r.Street)
                .NotEmpty().WithMessage("Nome da rua é obrigatório")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(r => r.Number)
                .NotEmpty().WithMessage("Número é obrigatório")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(r => r.State)
               .NotEmpty().WithMessage("Estado é obrigatório")
               .Length(2, 50).WithMessage("O campo {PropertyName} precisa conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(r => r.City)
                .NotEmpty().WithMessage("Cidade é obrigatório")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(r => r.ZipCode)
                .NotEmpty().WithMessage("Cep é obrigatório")
                .Length(8).WithMessage("O campo {PropertyName} precisa conter ter {MaxLength} caracteres");
        }
    }
}
