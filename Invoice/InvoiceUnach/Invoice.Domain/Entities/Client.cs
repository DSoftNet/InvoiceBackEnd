using System;
using System.Collections.Generic;
using Invoice.Domain.Exceptions;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Entities
{
    public class Client : BaseEntity
    {
        #region Constructor & properties
        
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string FirstLastName { get; private set; }
        public string SecondLastName { get; private set; }
        public string IdentificationType { get; private set; }
        public string Identification { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string CellPhone { get; private set; }
        public bool Status { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public Guid UserId { get; private set; }

        private readonly List<ItemCatalog> _itemCatalogs;
        
        protected Client()
        {
            Id = Guid.NewGuid();
            _itemCatalogs = new List<ItemCatalog>();
        }
        
        public Client(string firstName, string secondName, string firstLastName, string secondLastName, 
            string identificationType, string identification, string email, string address, string phone,
            string cellPhone, bool status, DateTime registrationDate, DateTime updateDate, Guid userId)
        {
            SetFirstName(firstName);
            SetSecondName(secondName);
            SetFirstLastName(firstLastName);
            SetSecondLastName(secondLastName);
            SetIdentificationType(identificationType);
            SetIdentification(identification);
            SetEmail(email);
            SetAddress(address);
            SetPhone(phone);
            SetCellPhone(cellPhone);
            SetStatus(status);
            SetRegistrationDate(registrationDate);
            SetUpdateDate(updateDate);
            SetUserId(userId);
        }

        #endregion

        #region Setters
        
        public void SetFirstName(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The firstname is required.");

            FirstName = value;
        }
        
        public void SetSecondName(string value)
        {
            SecondName = value;
        }
        
        public void SetFirstLastName(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The firstLastname is required.");

            FirstLastName = value;
        }
        
        public void SetSecondLastName(string value)
        {
            SecondLastName = value;
        }
        
        public void SetIdentificationType(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The identification type is required.");

            IdentificationType = value;
        }
        
        public void SetIdentification(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The identification is required.");

            Identification = value;
        }
        
        public void SetEmail(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The email is required.");

            Email = value;
        }
        
        public void SetAddress(string value)
        {
            Address = value;
        }
        
        public void SetPhone(string value)
        {
            Phone = value;
        }
        
        public void SetCellPhone(string value)
        {
            CellPhone = value;
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
            if (value == Guid.Empty) throw new InvoiceDomainException("The userid is required.");
            UserId = value;
        }

        #endregion

        #region Public Method

        public void CreateItemCatalog(string name, string value,
            string description, bool status, string codeCatalog)
        {
            var itemCatalog = new ItemCatalog(name, Identification, value, description, status, codeCatalog);
        }
        
        #endregion
    }
}