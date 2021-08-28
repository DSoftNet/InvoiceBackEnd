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
    

        public ReadClientsQueryHandler(ILogger<ReadClientsQueryHandler> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientResponse>> Handle(ReadClientsQuery query, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.Gets();

            /*return  clients.select(t => new ClientResponse(t.Id, t.firsName, t.secondName, t.firsLastName, 
                t.secondLastName,t.identificationType, t.identificationType, t.email, t.address, t.phone,
                t.cellPhone, t.status, t.userId)).ToList();*/
            return clients.Select(t => new ClientResponse(t.Id, t.FirstName, t.SecondName, t.FirstLastName, 
                t.SecondLastName, t.IdentificationType, t.Identification, t.Email, t.Address, t.Phone,
                t.CellPhone, t.Status, t.UserId)).ToList();
        }
    }
}