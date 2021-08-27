using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Dtos.Responses;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.Services.Validations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Queries
{
    public class ReadCatalogQueryHandler : IRequestHandler<ReadCatalogQuery, CatalogResponse>
    {
        private readonly ILogger<ReadCatalogQueryHandler> _logger;
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMediator _mediator;

        public ReadCatalogQueryHandler(ILogger<ReadCatalogQueryHandler> logger, ICatalogRepository catalogRepository,
            IMediator mediator)
        {
            _logger = logger;
            _catalogRepository = catalogRepository;
            _mediator = mediator;
        }

        public async Task<CatalogResponse> Handle(ReadCatalogQuery query, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ValidateCatalogService(query.Code), cancellationToken);
            
            var catalog = await _catalogRepository.GetByCode(query.Code);

            return new CatalogResponse(catalog.Id, catalog.Name, catalog.Code, catalog.Value,
                catalog.Description, catalog.Status);
        }
    }
}