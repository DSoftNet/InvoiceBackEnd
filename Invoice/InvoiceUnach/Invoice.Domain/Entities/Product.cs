using System;
using Invoice.Domain.Exceptions;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Entities
{
    public class Product : BaseEntity
    {
        #region Constructor & properties

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Code { get; private set; }
        public decimal Price { get; private set; }
        public bool IsIva { get; private set; }
        public int Stock { get; private set; }
        public bool IsExpiration { get; private set; }
        public DateTime ExpirationAt { get; private set; }
        public bool Status { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public Guid UserId { get; private set; }

        protected Product()
        {
            Id = Guid.NewGuid();
        }

        public Product(string name, string description, string code, decimal price, bool isIva, int stock,
            bool isExpiration, DateTime expirationAt, bool status, DateTime registrationDate, DateTime updateDate,
            Guid userId)
        {
            SetName(name);
            SetDescription(description);
            SetCode(code);
            SetPrice(price);
            SetIsIva(isIva);
            SetStock(stock);
            SetIsExpiration(isExpiration);
            SetExpirationAt(expirationAt);
            SetStatus(status);
            SetRegistrationDate(registrationDate);
            SetUpdateDate(updateDate);
            SetUserId(userId);
        }

        #endregion

        #region Setters

        public void SetName(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The name is required.");
            Name = value;
        }

        public void SetDescription(string value)
        {
            Description = value;
        }

        public void SetCode(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The code is required.");
            Code = value;
        }

        public void SetPrice(decimal value)
        {
            Price = value;
        }

        public void SetIsIva(bool value)
        {
            IsIva = value;
        }

        public void SetStock(int value)
        {
            Stock = value;
        }
        
        public void SetIsExpiration(bool value)
        {
            IsExpiration = value;
        }
        
        public void SetExpirationAt(DateTime value)
        {
            ExpirationAt = value;
        }

        public void SetStatus(bool value)
        {
            Status = value;
        }

        public void SetRegistrationDate(DateTime value)
        {
            RegistrationDate = value;
        }

        public void SetUpdateDate(DateTime value)
        {
            UpdateDate = value;
        }

        public void SetUserId(Guid value)
        {
            UserId = value;
        }

        #endregion
    }
}
