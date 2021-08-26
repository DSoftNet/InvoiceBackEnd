using System;
using MediatR;

namespace Invoice.Domain.Services.Validations
{
    public class ValidateCatalogService : IRequest<bool>
    {
        public Guid Id { get; private set; }

        public ValidateCatalogService(Guid id)
        {
            Id = id;
        }
    }
}