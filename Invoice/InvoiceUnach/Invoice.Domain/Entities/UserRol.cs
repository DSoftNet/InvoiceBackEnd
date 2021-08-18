using System;
using Invoice.Domain.Exceptions;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Entities
{
    public class UserRol : BaseEntity
    {
        #region Constructor & properties

        public string RolName { get; private set; }
        public Guid UserId { get; private set; }

        protected UserRol()
        {
            Id = Guid.NewGuid();
        }
        public UserRol(string rolName, Guid userId)
        {
            SetRolName(rolName);
            SetUserId(userId);
        }
        #endregion

        #region Setters

        public void SetRolName(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The name is required.");

            RolName = value;
        }

        public void SetUserId(Guid value)
        {
            if (value==Guid.empty) throw new InvoiceDomainException("The code catalog is required.");

            UserId = value;
          
        }

       
        #endregion
    }
}