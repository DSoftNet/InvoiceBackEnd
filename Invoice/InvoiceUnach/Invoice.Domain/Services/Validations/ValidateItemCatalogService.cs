using System;
using MediatR;

namespace Invoice.Domain.Services.Validations
{
    public class ValidateItemCatalogService : IRequest<bool>
    {
        public string Code { get; private set; }

        public ValidateItemCatalogService(string code)
        {
            Code = code;
        }
    }
}