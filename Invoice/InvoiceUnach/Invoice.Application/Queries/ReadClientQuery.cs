using System;
using System.Collections.Generic;
using Invoice.Application.Dtos.Responses;
using MediatR;

namespace Invoice.Application.Queries
{
    public class ReadClientQuery : IRequest<ClientResponse>
    {
        public Guid IdClient{ get; private set; }
        public Guid UserId{ get; private set; }

        public ReadClientQuery(Guid idClient, Guid userId)
        {
            IdClient = idClient;
            UserId = userId;
        }

    }
}