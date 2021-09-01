using System;
using System.Collections.Generic;
using Invoice.Application.Dtos.Responses;
using MediatR;

namespace Invoice.Application.Queries
{
    public class ReadSubsidiariesQuery : IRequest<List<SubsidiaryResponse>>
    {
        public Guid UserId{ get; private set; }

        public ReadSubsidiariesQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}