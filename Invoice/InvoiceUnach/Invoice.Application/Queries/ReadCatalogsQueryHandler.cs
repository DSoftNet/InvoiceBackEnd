using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Dtos.Responses;
using Invoice.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Queries
{
    public class ReadCatalogsQueryHandler : IRequestHandler<ReadCatalogsQuery, List<CatalogResponse>>
    {
        private readonly ILogger<ReadCatalogsQueryHandler> _logger;
        private readonly ICatalogRepository _catalogRepository; 
        
        public ReadCatalogsQueryHandler(ILogger<ReadCatalogsQueryHandler> logger, ICatalogRepository catalogRepository)
        {
            _logger = logger;
            _catalogRepository = catalogRepository;
        }
        
        public async Task<List<CatalogResponse>> Handle(ReadCatalogsQuery query, CancellationToken cancellationToken)
        {
            /*var catalogs = await _catalogRepository.Get();
            List<CatalogResponse> catalogResponses = new List<CatalogResponse>();
            
            foreach (var catalog in catalogs)
            {
                catalogResponses.Add(new CatalogResponse(catalog.Id, catalog.Name, catalog.Code, catalog.Value,
                    catalog.Description, catalog.Status));
            }

            return catalogResponses;*/
            
            var catalogs = await _catalogRepository.Get();

            return  catalogs.Select(t => new CatalogResponse(t.Id, t.Name, t.Code, t.Value, t.Description,
                t.Status)).ToList();
        }
    }
}