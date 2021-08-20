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
        public string Status { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }

        private readonly List<UserRol> _userRols;
        public IReadOnlyCollection<UserRol> UserRols => _userRols;
        
        private readonly List<Subsidiary> _subsidiaries;
        public IReadOnlyCollection<Subsidiary> Subsidiaries => _subsidiaries;
        
        private readonly List<Client> _clients;
        public IReadOnlyCollection<Client> Clients => _clients;

        private readonly List<Product> _products;
        public IReadOnlyCollection<Product> Products => _products;


        protected User()
        {
            Id = Guid.NewGuid();
            _userRols = new List<UserRol>();
            _subsidiaries = new List<Subsidiary>();
            _clients = new List<Client>();
            _products=new List<Product>();
        }

        public User(string firstName, string secondName, string firstLastName, string secondLastName,
            string identificationType, string identification, string email, string address, string phone,
            string cellPhone, string userName, string password, string status, DateTime createAt,
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

        public void SetStatus(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new InvoiceDomainException("The status is required.");
            
            Status = value;
        }

        #endregion

        #region Public Method

        public void CreateUserRol(string rolName)
        {
            var userRol = new UserRol(rolName, Id);
            _userRols.Add(userRol);
        }

        public void CreateSubsidiary(string name, string address, string phone1, string phone2)
        {
            var subsidiary = new Subsidiary(name, address,phone1,phone2, Id);
            _subsidiaries.Add(subsidiary);
        }
        
        public void CreateClient(string firstName, string secondName, string firstLastName, string secondLastName, 
            string identificationType, string identification, string email, string address, string phone,
            string cellPhone, bool status)
        {
            var client = new Client(firstName, secondName, firstLastName, secondLastName, identificationType,
                identification, email, address, phone, cellPhone, status, Id);
            _clients.Add(client);
        }


        public void CreateProduct(string name, string description, string code, decimal price, bool isIva, int stock,
            bool isExpiration, DateTime expirationAt, bool status, Guid userId)
            {
                var product= new Product(name, description, code, price, isIva,  stock, isExpiration, expirationAt, 
                status, userId);
                _products.Add(product);

            }

        #endregion
    }
}