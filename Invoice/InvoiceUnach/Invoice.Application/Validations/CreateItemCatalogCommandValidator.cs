using FluentValidation;
using Invoice.Application.Commands;

namespace Invoice.Application.Validations
{
    public class CreateItemCatalogCommandValidator : AbstractValidator<CreateItemCatalogCommand>
    {
        public CreateItemCatalogCommandValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty();
            
            RuleFor(t => t.Value)
                .NotEmpty();
            
            RuleFor(t => t.Description)
                .NotEmpty();
            RuleFor(t => t.CodeCatalog)
                .NotEmpty();
        }
    }
}