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
<<<<<<< HEAD
        public Guid UserId { get; private set; }
=======
        public int Userld { get; private set; }
>>>>>>> b186cb805d1c28249c730e96f124c95ce0550fe1

        protected Product()
        {
            Id = Guid.NewGuid();
        }

<<<<<<< HEAD
        public Product(string name, string description, string code, decimal price, bool isIva, int stock,
            bool isExpiration, DateTime expirationAt, bool status, DateTime registrationDate, DateTime updateDate,
            Guid userId)
=======
        public Product(string name, string description, string code,  decimal price, bool IsIva, int stock, bool IsExpiration,
            DateTime ExpirationAt, bool status, DateTime RegistrationDate, DateTime UpdateDate, int UserId)
>>>>>>> b186cb805d1c28249c730e96f124c95ce0550fe1
        {
            SetName(name);
            SetDescription(description);
            SetCode(code);
            SetPrice(price);
            SetIsIva(isIva);
            SetStock(stock);
<<<<<<< HEAD
            SetIsExpiration(isExpiration);
            SetExpirationAt(expirationAt);
            SetStatus(status);
            SetRegistrationDate(registrationDate);
            SetUpdateDate(updateDate);
            SetUserId(userId);
=======
            SetIsExpiration(IsExpiration);
            SetExpirationAt(ExpirationAt);
            SetStatus(status);
            SetRegistrationDate(RegistrationDate);
            SetUpdateDate(UpdateDate);
            SetUserId(UserId);
>>>>>>> b186cb805d1c28249c730e96f124c95ce0550fe1
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
<<<<<<< HEAD
=======
            //if (int.IsNullOrEmpty(value)) throw new InvoiceDomainException("The value is required.");
>>>>>>> b186cb805d1c28249c730e96f124c95ce0550fe1
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
<<<<<<< HEAD
            UserId = value;
=======
            Userld = value;
>>>>>>> b186cb805d1c28249c730e96f124c95ce0550fe1
        }

        #endregion
    }
}
