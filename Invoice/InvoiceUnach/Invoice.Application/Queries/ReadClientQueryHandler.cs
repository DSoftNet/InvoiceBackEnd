using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Dtos.Responses;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.Services.Validations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Queries
{
    public class ReadClientQueryHandler : IRequestHandler<ReadClientQuery, ClientResponse>
    {
        private readonly ILogger<ReadClientQueryHandler> _logger;
        private readonly IClientRepository _clientRepository;
        private readonly IMediator _mediator;

        public ReadClientQueryHandler(ILogger<ReadClientQueryHandler> logger, IClientRepository clientRepository,
            IMediator mediator)
        {
            _logger = logger;
            _clientRepository = clientRepository;
            _mediator = mediator;
        }

        public async Task<ClientResponse> Handle(ReadClientQuery query, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ValidateUserService(query.UserId), cancellationToken);
            
            var client = await _clientRepository.Get(query.IdClient);

            return new ClientResponse(client.Id, client.FirstName, client.SecondName, client.FirstLastName, 
                client.SecondLastName, client.IdentificationType, client.Identification, client.Email, client.Address,
                client.Phone, client.CellPhone, client.Status, client.UserId);
        }
    }
}