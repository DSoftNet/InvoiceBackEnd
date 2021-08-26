using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.Services.Validations;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Invoice.Application.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        #region Properties & Contructor

        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger,
            IProductRepository productRepository, IMediator mediator)
        {
            _logger = logger;
            _productRepository = productRepository;
            _mediator = mediator;
        }

        #endregion
        
        public async Task<bool> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            await ValidateCode(command);
            
            var product = new Product(command.Name, command.Description, command.Code, command.Price, command.IsIva,
                command.Stock, command.IsExpiration, command.ExpirationAt, command.Status, command.UserId);

            _productRepository.Add(product);
            await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
        
        #region Private Methods

        private async Task ValidateCode(CreateProductCommand command)
        {
            var catalog = await _productRepository.GetByCode(command.Code.ToUpper().Trim());

            if (catalog != null)
            {
                throw new InvoiceDomainException($"The code {command.Code} already exist.", HttpStatusCode.BadRequest);
            }
        }

        #endregion
    }
}