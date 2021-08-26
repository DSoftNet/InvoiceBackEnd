using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Domain.Exceptions;
using Invoice.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Domain.Services.Validations
{
    public class ValidateItemCatalogServiceHandler : IRequestHandler<ValidateItemCatalogService, bool>
    {
        #region Properties & Constructor

        private readonly ILogger<ValidateItemCatalogServiceHandler> _logger;
        private readonly IItemCatalogRepository _itemCatalogRepository;

        public ValidateItemCatalogServiceHandler(ILogger<ValidateItemCatalogServiceHandler> logger, IItemCatalogRepository itemCatalogRepository)
        {
            _logger = logger;
            _itemCatalogRepository = itemCatalogRepository;
        }

        #endregion

        public async Task<bool> Handle(ValidateItemCatalogService service, CancellationToken cancellationToken)
        {
            var catalog = await _itemCatalogRepository.GetById(service.Id);

            if (catalog == null)
            {
                throw new InvoiceDomainException($"The item catalog id {service.Id} doesn't exist.",
                    HttpStatusCode.BadRequest);
            }

            return true;
        }
    }
}