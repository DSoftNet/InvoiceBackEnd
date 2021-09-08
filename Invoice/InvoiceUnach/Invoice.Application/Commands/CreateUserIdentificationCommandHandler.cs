using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Dtos.Responses;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Commands
{
    public class CreateUserIdentificationCommandHandler : IRequestHandler<CreateUserIdentificationCommand, UserResponse>
    {
        private readonly ILogger<CreateUserIdentificationCommandHandler> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        
        public CreateUserIdentificationCommandHandler(ILogger<CreateUserIdentificationCommandHandler> logger,
            IUserRepository userRepository, IMediator mediator)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mediator = mediator;
        }
        
        public async Task<UserResponse> Handle(CreateUserIdentificationCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdentificationOrId(command.Identification,command.Id);
            return new UserResponse(user.Id,user.FirstName,user.SecondName,user.FirstLastName,user.SecondLastName,
                user.IdentificationType,user.Identification,user.Email,user.Address,user.Phone,user.CellPhone,
                user.UserName, user.Status);
            
        }

    }
}