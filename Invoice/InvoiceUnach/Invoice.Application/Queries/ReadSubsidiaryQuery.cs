using System;
using Invoice.Application.Dtos.Responses;
using MediatR;

namespace Invoice.Application.Queries
{
    public class ReadSubsidiaryQuery : IRequest<SubsidiaryResponse>
    {
        public Guid SubsidiaryId { get; private set; }
        public Guid UserId { get; private set; }

        public ReadSubsidiaryQuery(Guid subsidiaryId, Guid userId)
        {
            SubsidiaryId = subsidiaryId;
            UserId = userId;
        }
    }
}