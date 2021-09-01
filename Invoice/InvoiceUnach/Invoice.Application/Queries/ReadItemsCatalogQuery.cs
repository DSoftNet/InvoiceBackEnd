using System.Collections.Generic;
using Invoice.Application.Dtos.Responses;
using MediatR;

namespace Invoice.Application.Queries
{
    public class ReadItemsCatalogQuery: IRequest<List<ItemCatalogResponse>>
    {
        public string Code { get; private  set; }
        
        public ReadItemsCatalogQuery(string code)
        {
            Code = code;
        }
      
    }
}