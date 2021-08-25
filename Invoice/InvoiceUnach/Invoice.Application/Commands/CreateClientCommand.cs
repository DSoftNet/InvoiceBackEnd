using System;
using MediatR;

namespace Invoice.Application.Commands
{
    public class CreateClientCommand : IRequest<bool>
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
        public bool Status { get; private set; }
        public Guid UserId { get; private set; }

        public CreateClientCommand(string firstName, string secondName, string firstLastName, string secondLastName,
            string identificationType, string identification, string email, string address, string phone,
            string cellPhone, bool status, DateTime createAt, DateTime updateAt, Guid userId)
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
            Status = status;
            UserId = userId;
        }
    }
}