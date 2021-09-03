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
    public class ReadItemsCatalogQueryHandler : IRequestHandler<ReadItemsCatalogQuery, List<ItemCatalogResponse>>
    {
        private readonly ILogger<ReadItemsCatalogQueryHandler> _logger;
        private readonly IItemCatalogRepository _itemCatalogRepository;
        private readonly IMediator _mediator;


        public ReadItemsCatalogQueryHandler(ILogger<ReadItemsCatalogQueryHandler> logger, IItemCatalogRepository
                itemCatalogRepository,
            IMediator mediator)
        {
            _logger = logger;
            _itemCatalogRepository = itemCatalogRepository;
            _mediator = mediator;
        }

        public async Task<List<ItemCatalogResponse>> Handle(ReadItemsCatalogQuery query, CancellationToken
            cancellationToken)
        {
            await _mediator.Send(new ValidateCatalogService(query.Code), cancellationToken);

            var itemsCatalog = await _itemCatalogRepository.Get();

            return itemsCatalog.Select(t => new ItemCatalogResponse(t.Name, t.Code, t.Value, t.Description,
                t.Status, t.CodeCatalog)).ToList();
        }
    }
}