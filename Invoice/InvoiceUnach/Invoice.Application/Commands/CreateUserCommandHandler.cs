using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.Services.Validations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
      
        #region Properties & Contructor

        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        
        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, 
            IUserRepository userRepository,IMediator mediator)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mediator = mediator;
        }

        #endregion
        
        public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await Validate(command, cancellationToken);
            var user = new User(command.FirstName,command.SecondName,command.FirstLastName,command.SecondLastName,
                command.IdentificationType,command.Identification.Trim(),command.Email,command.Address,command.Phone,
                command.CellPhone,command.UserName,command.Password,command.Status);

            _userRepository.Add(user);
            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
        
        #region Private Methods
        
        private async Task Validate(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ValidateItemCatalogService(command.IdentificationType), cancellationToken);
            await _mediator.Send(new ValidateItemCatalogService(command.Status), cancellationToken);
            await ValidateIdentification(command);
        }
        
        private async Task ValidateIdentification(CreateUserCommand command)
        {
            var user = await _userRepository.GetByIdentification(command.Identification.Trim());

            if (user != null)
            {
                throw new InvoiceDomainException($"The Identification {command.Identification} already exist.",
                    HttpStatusCode.BadRequest);
            }
        }
      
        #endregion
    }
}