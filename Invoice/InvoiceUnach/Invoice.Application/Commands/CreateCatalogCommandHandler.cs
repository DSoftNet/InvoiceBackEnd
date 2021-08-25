using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Invoice.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Commands
{
    public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, bool>
    {
        #region Properties & Contructor

        private readonly ILogger<CreateCatalogCommandHandler> _logger;
        private readonly ICatalogRepository _catalogRepository;

        public CreateCatalogCommandHandler(ILogger<CreateCatalogCommandHandler> logger,
            ICatalogRepository catalogRepository)
        {
            _logger = logger;
            _catalogRepository = catalogRepository;
        }

        #endregion

        public async Task<bool> Handle(CreateCatalogCommand command, CancellationToken cancellationToken)
        {
            await ValidateCode(command);

            var catalog = new Catalog(command.Name, command.Code.ToUpper().Trim(), command.Value,
                command.Description, command.Status);

            _catalogRepository.Add(catalog);
            await _catalogRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }

        #region Private Methods

        private async Task ValidateCode(CreateCatalogCommand command)
        {
           var catalog = await _catalogRepository.GetByCode(command.Code.ToUpper().Trim());
           

            if (catalog != null)
            {
               throw new InvoiceDomainException($"The code {command.Code} already exist.", HttpStatusCode.BadRequest);
             }
        }

        #endregion
    }
}