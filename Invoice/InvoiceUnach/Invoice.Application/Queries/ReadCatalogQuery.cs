using Invoice.Application.Dtos.Responses;
using MediatR;

namespace Invoice.Application.Queries
{
    public class ReadCatalogQuery : IRequest<CatalogResponse>
    {
        public string Code { get; private set; }

        public ReadCatalogQuery(string code)
        {
            Code = code;
        }
    }
}