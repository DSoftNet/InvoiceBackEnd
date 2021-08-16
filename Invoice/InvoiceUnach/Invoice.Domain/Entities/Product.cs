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
        public string RegistrationDate { get; private set; }
        public string UpdateDate { get; private set; }
        public int Userld { get; private set; }

        protected Product()
        {
            Id = Guid.NewGuid();
        }

        public Product(string name, string description, string code,  decimal price, bool IsIva, int stock, bool IsExpiration,
         DateTime ExpirationAt, bool status, DateTime RegistrationDate, DateTime UpdateDate, int UserId)
        {
            SetName(name);
            SetDescription(description);
            SetCode(code);
            SetPrice(price);
            SetIsIva(IsIva);
            SetStock(stock);
            setIsExpiration(IsExpiration);
            setExpirationAt(ExpirationAt);
            setStatus(status);
            setRegistrationDate(RegistrationDate);
            setUpdateDate(UpdateDate);
            setUserId(UserId);
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
            if (int.IsNullOrEmpty(value)) throw new InvoiceDomainException("The value is required.");
            Stock = value;
        }

        public void SetIsExpiration(bool value)
        {
            Value = value;
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

        public void SetUserId(int value)
        {
            IdUser = value;
        }

        #endregion
    }
}