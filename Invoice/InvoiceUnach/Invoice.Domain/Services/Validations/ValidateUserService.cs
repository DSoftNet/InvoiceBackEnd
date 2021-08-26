using System;
using MediatR;

namespace Invoice.Domain.Services.Validations
{
    public class ValidateUserService : IRequest<bool>
    {
        public Guid Id { get; private set; }

        public ValidateUserService(Guid id)
        {
            Id = id;
        }
    }
}