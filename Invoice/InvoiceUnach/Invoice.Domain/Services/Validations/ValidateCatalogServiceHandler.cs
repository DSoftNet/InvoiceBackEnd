using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Domain.Exceptions;
using Invoice.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Domain.Services.Validations
{
    public class ValidateCatalogServiceHandler : IRequestHandler<ValidateCatalogService, bool>
    {
        #region Properties & Constructor

        private readonly ILogger<ValidateCatalogServiceHandler> _logger;
        private readonly ICatalogRepository _catalogRepository;

        public ValidateCatalogServiceHandler(ILogger<ValidateCatalogServiceHandler> logger, ICatalogRepository catalogRepository)
        {
            _logger = logger;
            _catalogRepository = catalogRepository;
        }

        #endregion

        public async Task<bool> Handle(ValidateCatalogService service, CancellationToken cancellationToken)
        {
            var catalog = await _catalogRepository.GetByCode(service.Code);

            if (catalog == null)
            {
                throw new InvoiceDomainException($"The code from catalog {service.Code} doesn't exist.",
                    HttpStatusCode.BadRequest);
            }

            return true;
        }
    }
}