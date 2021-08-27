using FluentValidation;
using Invoice.Application.Commands;

namespace Invoice.Application.Validations
{
    public class CreateSubsidiaryCommandValidator : AbstractValidator<CreateSubsidiaryCommand>
    {
        public CreateSubsidiaryCommandValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty();
            
            RuleFor(t => t.Address)
                .NotEmpty();
            
            RuleFor(t => t.Phone1)
                .NotEmpty();
            
            RuleFor(t => t.Phone2)
                .NotEmpty();
        }

    }
}