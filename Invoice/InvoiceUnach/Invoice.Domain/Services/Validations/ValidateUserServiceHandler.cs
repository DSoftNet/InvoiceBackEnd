using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Domain.Exceptions;
using Invoice.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Domain.Services.Validations
{
    public class ValidateUserServiceHandler : IRequestHandler<ValidateUserService, bool>
    {
        #region Properties & Constructor

        private readonly ILogger<ValidateUserServiceHandler> _logger;
        private readonly IUserRepository _userRepository;

        public ValidateUserServiceHandler(ILogger<ValidateUserServiceHandler> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        #endregion

        public async Task<bool> Handle(ValidateUserService service, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(service.Id);

            if (user == null)
            {
                throw new InvoiceDomainException($"The user id {service.Id} doesn't exist.",
                    HttpStatusCode.BadRequest);
            }

            return true;
        }
    }
}