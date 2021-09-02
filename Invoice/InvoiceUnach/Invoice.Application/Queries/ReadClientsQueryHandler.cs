using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Dtos.Responses;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.Services.Validations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Queries
{
    public class ReadClientsQueryHandler : IRequestHandler<ReadClientsQuery, List<ClientResponse>>
    {
        private readonly ILogger<ReadClientsQueryHandler> _logger;
        private readonly IClientRepository _clientRepository;
        private readonly IMediator _mediator;


        public ReadClientsQueryHandler(ILogger<ReadClientsQueryHandler> logger, IClientRepository clientRepository,
            IMediator mediator)
        {
            _logger = logger;
            _clientRepository = clientRepository;
            _mediator = mediator;
        }

        public async Task<List<ClientResponse>> Handle(ReadClientsQuery query, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ValidateUserService(query.UserId), cancellationToken);

            var clients = await _clientRepository.Get(query.UserId);

            return clients.Select(t => new ClientResponse(t.Id, t.FirstName, t.SecondName, t.FirstLastName,
                t.SecondLastName, t.IdentificationType, t.Identification, t.Email, t.Address, t.Phone,
                t.CellPhone, t.Status, t.UserId)).ToList();
        }
    }
}