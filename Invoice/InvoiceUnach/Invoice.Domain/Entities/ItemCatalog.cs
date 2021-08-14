using System;
using Invoice.Domain.Exceptions;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Entities
{
    public class ItemCatalog : BaseEntity
    {
        #region Constructor & properties

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Value { get; private set; }
        public string Description { get; private set; }
        public bool Status { get; private set; }
        public string CodeCatalog { get; private set; }

        protected ItemCatalog()
        {
            Id = Guid.NewGuid();
        }

        public ItemCatalog(string name, string code, string value,
            string description, bool status, string codeCatalog)
        {
            SetName(name);
            SetCode(code);
            SetValue(value);
            SetDescription(description);
            SetStatus(status);
            SetCodeCatalog(codeCatalog);
        }

        #endregion

        #region Setters

        public void SetName(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The name is required.");

            Name = value;
        }

        public void SetCode(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The code is required.");

            Code = value;
        }

        public void SetValue(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The value is required.");

            Value = value;
        }

        public void SetDescription(string value)
        {
            Description = value;
        }

        public void SetStatus(bool value)
        {
            Status = value;
        }

        public void SetCodeCatalog(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The code catalog is required.");

            CodeCatalog = value;
        }

        #endregion
    }
}