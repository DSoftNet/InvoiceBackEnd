using FluentValidation;
using Invoice.Domain.Exceptions;
using Invoice.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Behavior
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorBehavior(ILogger<ValidatorBehavior<TRequest, TResponse>> logger,
            IValidator<TRequest>[] validators)
        {
            _logger = logger;
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            
            var typeName = request.GetGenericTypeName();

            _logger.LogInformation("--- Validating command {CommandType}", typeName);

            var failures = _validators
                .Select(x => x.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                _logger.LogWarning("Validation errors - {CommanType} - Command: {@Command} - Errors: {@ValidateErrors}",
                    typeName, request, failures);

                throw new InvoiceDomainException($"Some validation errorss were found",
                    new ValidationException("Validation exception", failures));
            }

            return await next();
        }
    }
}