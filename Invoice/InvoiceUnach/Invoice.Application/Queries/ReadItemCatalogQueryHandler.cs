using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Dtos.Responses;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.Services.Validations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Queries
{
    public class ReadItemCatalogQueryHandler : IRequestHandler<ReadItemCatalogQuery, ItemCatalogResponse>
    {
        private readonly ILogger<ReadItemCatalogQueryHandler> _logger;
        private readonly IItemCatalogRepository _itemCatalogRepository;
        private readonly IMediator _mediator;

        public ReadItemCatalogQueryHandler(ILogger<ReadItemCatalogQueryHandler> logger, IItemCatalogRepository itemCatalogRepository,
            IMediator mediator)
        {
            _logger = logger;
            _itemCatalogRepository = itemCatalogRepository;
            _mediator = mediator;
        }

        public async Task<ItemCatalogResponse> Handle(ReadItemCatalogQuery query, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ValidateItemCatalogService(query.Code), cancellationToken);
            
            var itemCatalog = await _itemCatalogRepository.GetByCode(query.Code);

            return new ItemCatalogResponse(itemCatalog.Name, itemCatalog.Code, itemCatalog.Value, 
                itemCatalog.Description, itemCatalog.Status, itemCatalog.CodeCatalog);
        }
    }
}