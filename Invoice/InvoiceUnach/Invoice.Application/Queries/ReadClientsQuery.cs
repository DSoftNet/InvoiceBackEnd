using System;
using System.Collections.Generic;
using Invoice.Application.Dtos.Responses;
using MediatR;

namespace Invoice.Application.Queries
{
    public class ReadClientsQuery : IRequest<List<ClientResponse>>
    {
        public Guid UserId{ get; private set; }

        public ReadClientsQuery(Guid userId)
        {
            UserId = userId;
        }
        
    }
}