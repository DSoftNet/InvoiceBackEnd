using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Dtos.Responses;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.Services.Validations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Invoice.Application.Queries
{
    public class ReadSubsidiariesQueryHandler : IRequestHandler<ReadSubsidiariesQuery, List<SubsidiaryResponse>>
    {
        private readonly ILogger<ReadSubsidiariesQueryHandler> _logger;
        private readonly ISubsidiaryRepository _subsidiaryRepository;
        private readonly IMediator _mediator;

        public ReadSubsidiariesQueryHandler(ILogger<ReadSubsidiariesQueryHandler> logger,
            ISubsidiaryRepository subsidiaryRepository, IMediator mediator)
        {
            _logger = logger;
            _subsidiaryRepository = subsidiaryRepository;
            _mediator = mediator;
        }

        public async Task<List<SubsidiaryResponse>> Handle(ReadSubsidiariesQuery query,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(new ValidateUserService(query.UserId), cancellationToken);

            var subsidiaries = await _subsidiaryRepository.Get();

            return subsidiaries.Select(x => new SubsidiaryResponse(x.Id, x.Name, x.Address, x.Phone1, 
                    x.Phone2, x.UserId)).ToList();
        }
    }
}