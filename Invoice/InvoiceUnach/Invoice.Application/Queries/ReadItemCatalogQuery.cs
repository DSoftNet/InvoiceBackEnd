using Invoice.Application.Dtos.Responses;
using MediatR;

namespace Invoice.Application.Queries
{
    public class ReadItemCatalogQuery : IRequest<ItemCatalogResponse>
    {
        
            public string Code { get; private set; }
            public string CodeCatalog { get; private set; }

            public ReadItemCatalogQuery(string code, string codeCatalog)
            {
                Code = code;
                CodeCatalog = codeCatalog;
            }
        
    }
}