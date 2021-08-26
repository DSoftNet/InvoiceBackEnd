using MediatR;
using System;

namespace Invoice.Application.Commands
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Code { get; private set; }
        public decimal Price { get; private set; }
        public bool IsIva { get; private set; }
        public int Stock { get; private set; }
        public bool IsExpiration { get; private set; }
        public DateTime ExpirationAt { get; private set; }
        public bool Status { get; private set; }
        public Guid UserId { get; private set; }
        
        public CreateProductCommand(string name, string description, string code, decimal price, bool isIva, int stock,
         bool isExpiration, DateTime expirationAt, bool status, Guid userId)
        {
            Name = name;
            Description = description;
            Code = code;
            Price = price;
            IsIva = isIva;
            Stock = stock;
            IsExpiration = isExpiration;
            ExpirationAt = expirationAt;
            Status = status;
            UserId = userId;
        }
    }
}