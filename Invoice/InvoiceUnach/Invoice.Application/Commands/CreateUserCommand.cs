using System;
using MediatR;

namespace Invoice.Application.Commands
{
    public class CreateUserCommand: IRequest<bool>
    {
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
        
        public CreateUserCommand(string firstName, string secondName, string firstLastName, string secondLastName, string identificationType, 
            string identification, string email, string address, string phone, string cellPhone, string userName, string password, string status, 
            DateTime createAt, DateTime updateAt)
        {
            FirstName = firstName;
            SecondName = secondName;
            FirstLastName = firstLastName;
            SecondLastName = secondLastName;
            IdentificationType = identificationType;
            Identification = identification;
            Email = email;
            Address = address;
            Phone = phone;
            CellPhone = cellPhone;
            UserName = userName;
            Password = password;
            Status = status;
            CreateAt = createAt;
            UpdateAt = updateAt;
        }
    }
}