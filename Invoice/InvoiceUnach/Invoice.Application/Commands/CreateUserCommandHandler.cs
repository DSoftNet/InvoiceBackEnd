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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
      
        #region Properties & Contructor

        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IUserRepository _userRepository;
        
        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, 
            IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        #endregion
        
        public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await ValidateIdentification(command);
            var user = new User(command.FirstName,command.SecondName,command.FirstLastName,command.SecondLastName,
                command.IdentificationType,command.Identification.ToUpper().Trim(),command.Email,command.Address,command.Phone,
                command.CellPhone,command.UserName,command.Password,command.Status,command.CreateAt,command.UpdateAt);

            _userRepository.Add(user);
            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
        
        #region Private Methods
        
        private async Task ValidateIdentification(CreateUserCommand command)
        {
            var user = await _userRepository.GetByIdentification(command.Identification.ToUpper().Trim());

            if (user != null)
            {
                throw new InvoiceDomainException($"The Identification {command.Identification} already exist.", HttpStatusCode.BadRequest);
            }
        }
      
        #endregion
    }
}