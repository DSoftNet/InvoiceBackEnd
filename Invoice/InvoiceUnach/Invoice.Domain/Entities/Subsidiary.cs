using System;
using Invoice.Domain.Exceptions;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Entities
{
    public class Subsidiary : BaseEntity
    {
        #region Constructor & Properties

        public string Name { get; private set; }
        public string Address{ get; private set; }
        public string Phone1 { get; private set; }
        public string Phone2 { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
		public Guid UserId { get; private set; }


         protected Subsidiary()
        {
            Id = Guid.NewGuid();
        }

        public Subsidiary(string name, string address, string phone1, string phone2, 
			   DateTime registrationDate, DateTime updateDate, Guid userId )
		{
			SetName(name);
            SetAddress(address);
            SetPhone1(phone1);
            SetPhone2(phone2);
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
        public void SetAddress(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The address is required.");

            Address = value;
        }
        public void SetPhone1(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The phone1 is required.");

            Phone1 = value;
        }
        public void SetPhone2(string value)
        {
            Phone2 = value;
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
            if (value == Guid.Empty) throw new InvoiceDomainException("The UserId is required.");
            
            UserId = value;
        }

        #endregion
          
    }
}