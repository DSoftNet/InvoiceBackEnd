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
    public class CreateItemCatalogCommandHandler : IRequestHandler<CreateItemCatalogCommand, bool>
    {
        #region Properties & Contructor
        private readonly ILogger<CreateItemCatalogCommandHandler> _logger;
        private readonly IItemCatalogRepository _itemCatalogRepository;
        
        public CreateItemCatalogCommandHandler(ILogger<CreateItemCatalogCommandHandler> logger,
            IItemCatalogRepository itemCatalogRepository)
        {
            _logger = logger;
            _itemCatalogRepository= itemCatalogRepository;
        }

        #endregion
        
       public async Task<bool> Handle(CreateItemCatalogCommand command, CancellationToken cancellationToken)
               {
                   await ValidateCode(command);
                   
                   var itemCatalog = new ItemCatalog(command.Name, command.Code.ToUpper().Trim(), command.Value, 
                       command.Description, command.Status, command.CodeCatalg);
       
                   _itemCatalogRepository.Add(itemCatalog);
                   await _itemCatalogRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
       
                   return true;
               }
       #region Private Methods

       private async Task ValidateCode(CreateItemCatalogCommand command)
       {
           var itemCatalog = await _itemCatalogRepository.GetByCode(command.Code.ToUpper().Trim());

           if (itemCatalog != null)
           {
             throw new InvoiceDomainException($"The code {command.Code} already exist.", HttpStatusCode.BadRequest);
           }
       }

       #endregion
    }
}