using System;
using Invoice.Application.Dtos.Responses;
using Invoice.Domain.Entities;
using MediatR;

namespace Invoice.Application.Commands
{
    public class CreateUserIdentificationCommand : IRequest<UserResponse>
    {
        public Guid Id { get; private set; }
        public string Identification { get; private set; }
        
        public CreateUserIdentificationCommand(Guid id, string identification)
        {
            Id = id;
            Identification = identification;
        }

        
       
    }
}