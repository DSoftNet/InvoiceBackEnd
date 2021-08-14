using System;
using System.Collections.Generic;
using Invoice.Domain.Exceptions;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Entities
{
    public class Catalog : BaseEntity
    {
        #region Constructor & properties

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Value { get; private set; }
        public string Description { get; private set; }
        public bool Status { get; private set; }

        private readonly List<ItemCatalog> _itemCatalogs;

        protected Catalog()
        {
            Id = Guid.NewGuid();
            _itemCatalogs = new List<ItemCatalog>();
        }

        public Catalog(string name, string code, string value, string description, bool status)
        {
            SetName(name);
            SetCode(code);
            SetValue(value);
            SetDescription(description);
            SetStatus(status);
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

        #endregion

        #region Public Method

        public void CreateItemCatalog(string name, string code, string value,
            string description, bool status)
        {
            var itemCatalog = new ItemCatalog(name, code, value, description, status, Code);
        }

        #endregion
    }

    
}