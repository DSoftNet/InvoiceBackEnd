using System.Collections.Generic;
using Invoice.Application.Dtos.Responses;
using MediatR;

namespace Invoice.Application.Queries
{
    public class ReadCatalogsQuery : IRequest<List<CatalogResponse>>
    {
    }
}