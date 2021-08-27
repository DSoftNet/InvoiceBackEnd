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
    public class CreateSubsidiaryCommandHandler : IRequestHandler<CreateSubsidiaryCommand, bool>
    {
        #region Propierties & Constructor

        private readonly ILogger<CreateSubsidiaryCommandHandler> _logger;
        private readonly ISubsidiaryRepository _subsidiaryRepository;
        private readonly IMediator _mediator;

        public CreateSubsidiaryCommandHandler(ILogger<CreateSubsidiaryCommandHandler> logger,
            ISubsidiaryRepository subsidiaryRepository)
        {
            _logger = logger;
            _subsidiaryRepository = subsidiaryRepository;
        }

        #endregion

        public async Task<bool> Handle(CreateSubsidiaryCommand command, CancellationToken cancellationToken)
        {
            await ValidateCode(command);

            var subsidiary = new Subsidiary(command.Name, command.Address, command.Phone1, 
                command.Phone2, command.UserId);

            _subsidiaryRepository.Add(subsidiary);
            await _subsidiaryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
        
        #region Private Methods
        
        private async Task Validate(CreateSubsidiaryCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ValidateUserService(command.UserId), cancellationToken);
        }

        private async Task ValidateCode(CreateSubsidiaryCommand command)
        {
            var subsidiary = await _subsidiaryRepository.GetByCode(command.Address);

            if (subsidiary != null)
            {
                throw new InvoiceDomainException(message: $"The address {command.Address} already exist",
                    HttpStatusCode.Accepted);
            }
        }
        #endregion
    }
}