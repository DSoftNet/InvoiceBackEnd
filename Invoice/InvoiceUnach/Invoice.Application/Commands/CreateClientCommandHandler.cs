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
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, bool>
    {
        #region Properties & Contructor

        private readonly ILogger<CreateClientCommandHandler> _logger;
        private readonly IClientRepository _clientRepository;
        private readonly IMediator _mediator;

        public CreateClientCommandHandler(ILogger<CreateClientCommandHandler> logger,
            IClientRepository clientRepository, IMediator mediator)
        {
            _logger = logger;
            _clientRepository = clientRepository;
            _mediator = mediator;
        }

        #endregion

        public async Task<bool> Handle(CreateClientCommand command, CancellationToken cancellationToken)
        {
            await Validate(command, cancellationToken);

            var client = new Client(command.FirstName, command.SecondName, command.FirstLastName,
                command.SecondLastName, command.IdentificationType, command.Identification, command.Email.Trim(),
                command.Address, command.Phone, command.CellPhone, command.Status, command.UserId);

            _clientRepository.Add(client);
            await _clientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }

        #region Private Methods

        private async Task Validate(CreateClientCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ValidateUserService(command.UserId), cancellationToken);
            await _mediator.Send(new ValidateItemCatalogService(command.IdentificationType), cancellationToken);
            await ValidateEmail(command);
        }

        private async Task ValidateEmail(CreateClientCommand command)
        {
            var client = await _clientRepository.GetByEmail(command.Email.Trim());

            if (client != null)
            {
                throw new InvoiceDomainException($"The email {command.Email} already exist.",
                    HttpStatusCode.BadRequest);
            }
        }

        #endregion
    }
}