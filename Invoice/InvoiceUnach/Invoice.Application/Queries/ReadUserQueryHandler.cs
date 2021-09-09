using System;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Dtos.Responses;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.Services.Validations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Queries
{
    public class ReadUserQueryHandler :IRequestHandler<ReadUserQuery, UserResponse>
    {
        private readonly ILogger<ReadUserQueryHandler> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        
        public ReadUserQueryHandler(ILogger<ReadUserQueryHandler> logger, IUserRepository userRepository, IMediator mediator)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mediator = mediator;
        }
        
        public async Task<UserResponse> Handle(ReadUserQuery query, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetByIdentification(query.Code);

            return new UserResponse(user.Id,user.FirstName,user.SecondName,user.FirstLastName,user.SecondLastName,
                user.IdentificationType,user.Identification,user.Email,user.Address,user.Phone,user.CellPhone,
                user.UserName, user.Status);
            
        }
    }
}