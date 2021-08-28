
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Dtos.Responses;
using Invoice.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Queries
{
    public class ReadUsersQueryHandler : IRequestHandler<ReadUsersQuery, List<UserResponse>>
    {
        private readonly ILogger<ReadUsersQueryHandler> _logger;
        private readonly IUserRepository _userRepository; 
        
        public ReadUsersQueryHandler(ILogger<ReadUsersQueryHandler> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        
        public async Task<List<UserResponse>> Handle(ReadUsersQuery query, CancellationToken cancellationToken)
        {
            var users = await _userRepository.Get();

            return  users.Select(t => new UserResponse(t.Id,t.FirstName,t.SecondName,t.FirstLastName,
                t.SecondLastName,t.IdentificationType,t.Identification,t.Email,t.Address,t.Phone,t.CellPhone,
                t.UserName,t.Status)).ToList();
        }
    }
}