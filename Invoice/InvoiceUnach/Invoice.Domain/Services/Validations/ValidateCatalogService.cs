using System;
using MediatR;

namespace Invoice.Domain.Services.Validations
{
    public class ValidateCatalogService : IRequest<bool>
    {
        public string Code { get; private set; }

        public ValidateCatalogService(string code)
        {
            Code = code;
        }
    }
}