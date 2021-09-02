using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Domain.Exceptions;
using Invoice.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Domain.Services.Validations
{
    public class ValidateProductServiceHandler : IRequestHandler<ValidateProductService, bool>
    {
        #region Properties & Constructor

        private readonly ILogger<ValidateProductServiceHandler> _logger;
        private readonly IProductRepository _productRepository;

        public ValidateProductServiceHandler(ILogger<ValidateProductServiceHandler> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        #endregion

        public async Task<bool> Handle(ValidateProductService service, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByCode(service.Code);

            if (product == null)
            {
                throw new InvoiceDomainException($"The code from product {service.Code} doesn't exist.",
                    HttpStatusCode.BadRequest);
            }

            return true;
        }
    }
}