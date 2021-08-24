using FluentValidation;
using Invoice.Application.Commands;

namespace Invoice.Application.Validations
{
    public class CreateCatalogCommandValidator : AbstractValidator<CreateCatalogCommand>
    {
        public CreateCatalogCommandValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty();
            
            RuleFor(t => t.Value)
                .NotEmpty();
            
            RuleFor(t => t.Description)
                .NotEmpty();
        }
    }
}