using System;
using Invoice.Application.Dtos.Responses;
using MediatR;

namespace Invoice.Application.Queries
{
    public class ReadSubsidiaryQuery : IRequest<SubsidiaryResponse>
    {
        public Guid IdSubsidiary { get; private set; }
        public Guid UserId { get; private set; }

        public ReadSubsidiaryQuery(Guid idSubsidiary, Guid userId)
        {
            IdSubsidiary = idSubsidiary;
            UserId = userId;
        }
    }
}