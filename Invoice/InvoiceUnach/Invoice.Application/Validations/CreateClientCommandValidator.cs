using FluentValidation;
using Invoice.Application.Commands;

namespace Invoice.Application.Validations
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(t => t.FirstName)
                .NotEmpty();
            
            RuleFor(t => t.SecondName)
                .NotEmpty();
            
            RuleFor(t => t.FirstLastName)
                .NotEmpty();
            RuleFor(t => t.SecondLastName)
                .NotEmpty();
            RuleFor(t => t.IdentificationType)
                .NotEmpty();
            RuleFor(t => t.Identification)
                .NotEmpty();
            RuleFor(t => t.Email)
                .NotEmpty();
            RuleFor(t => t.Address)
                .NotEmpty();
            RuleFor(t => t.Phone)
                .NotEmpty();
            RuleFor(t => t.CellPhone)
                .NotEmpty();
            RuleFor(t => t.UserId)
                .NotEmpty();
        }
    }
}