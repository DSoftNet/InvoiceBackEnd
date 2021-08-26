using System;
using MediatR;

namespace Invoice.Domain.Services.Validations
{
    public class ValidateItemCatalogService : IRequest<bool>
    {
        public Guid Id { get; private set; }

        public ValidateItemCatalogService(Guid id)
        {
            Id = id;
        }
    }
}