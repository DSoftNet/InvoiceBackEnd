using System;
using MediatR;

namespace Invoice.Application.Commands
{
    public abstract class CreateSubsidiaryCommand : IRequest<bool>
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone1 { get; private set; }
        public string Phone2 { get; private set; }
        public Guid UserId { get; private set; }
        
        public CreateSubsidiaryCommand(string name, string address, string phone1, string phone2, Guid userId)
        {
            Name = name;
            Address = address;
            Phone1 = phone1;
            Phone2 = phone2;
            UserId = userId;
        }
    }
}