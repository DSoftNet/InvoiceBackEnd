using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Dtos.Responses;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.Services.Validations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Queries
{
    public class ReadSubsidiaryQueryHandler : IRequestHandler<ReadSubsidiaryQuery, SubsidiaryResponse>
    {
        private readonly ILogger<ReadSubsidiaryQueryHandler> _logger;
        private readonly ISubsidiaryRepository _subsidiaryRepository;
        private readonly IMediator _mediator;

        public ReadSubsidiaryQueryHandler(ILogger<ReadSubsidiaryQueryHandler> logger,
            ISubsidiaryRepository subsidiaryRepository, IMediator mediator)
        {
            _logger = logger;
            _subsidiaryRepository = subsidiaryRepository;
            _mediator = mediator;
        }

        public async Task<SubsidiaryResponse> Handle(ReadSubsidiaryQuery query, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ValidateUserService(query.UserId), cancellationToken);

            var subsidiary = await _subsidiaryRepository.GetByIdAndUserId(query.SubsidiaryId, query.UserId);

            return new SubsidiaryResponse(subsidiary.Id, subsidiary.Name, subsidiary.Address, subsidiary.Phone1,
                subsidiary.Phone2, subsidiary.UserId);
        } 
    }
}