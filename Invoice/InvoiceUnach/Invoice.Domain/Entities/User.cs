using System;
using System.Collections.Generic;
using Invoice.Domain.Exceptions;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Entities
{
    public class User : BaseEntity
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
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Status { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }

        private readonly List<UserRol> _userRols;
        private IReadOnlyCollection<UserRol> UserRols => _userRols;
        
        private readonly List<Client> _clients;
        private IReadOnlyCollection<Client> Clients => _clients;

        protected User()
        {
            Id = Guid.NewGuid();
            _userRols = new List<UserRol>();
        }

        public User(string firstName, string secondName, string firstLastName, string secondLastName,
            string identificationType, string identification, string email, string address, string phone,
            string cellPhone, string userName, string password, bool status, DateTime createAt,
            DateTime updateAt)
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
            SetUserName(userName);
            SetPassword(password);
            SetStatus(status);
            CreateAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
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
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The firstlastname is required.");

            FirstLastName = value;
        }

        public void SetSecondLastName(string value)
        {
            SecondLastName = value;
        }

        public void SetIdentificationType(string value)
        {
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

        public void SetUserName(string value)
        {
            UserName = value;
        }

        public void SetPassword(string value)
        {
            Password = value;
        }

        public void SetStatus(bool value)
        {
            Status = value;
        }

        #endregion

        #region Public Method

        public void CreateUserRol(string rolName)
        {
            var userRol = new UserRol(rolName, Id);
            _userRols.Add(userRol);
        }

        #endregion
    }
}