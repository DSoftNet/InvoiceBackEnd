using System;
using MediatR;

namespace Invoice.Domain.Services.Validations
{
    public class ValidateItemCatalogService : IRequest<bool>
    {
        public Guid Code{ get; private set; }

        public ValidateItemCatalogService(Guid code)
        {
            Code = code;
        }
    }
}