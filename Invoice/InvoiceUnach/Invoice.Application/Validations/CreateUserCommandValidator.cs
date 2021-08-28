using FluentValidation;
using Invoice.Application.Commands;
namespace Invoice.Application.Validations
{
    public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator ()
        {
            RuleFor(t => t.FirstName)
                .NotEmpty();
            
            RuleFor(t => t.FirstLastName)
                .NotEmpty();
            
            RuleFor(t => t.IdentificationType)
                .NotEmpty();

            RuleFor(t => t.Identification)
                .NotEmpty();
            
            RuleFor(t => t.Email)
                .NotEmpty();
            
            RuleFor(t => t.Status)
                .NotEmpty();
        }
    }
}