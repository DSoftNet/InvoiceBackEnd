using System;
namespace Invoice.Application.Dtos.Responses
{
    public class ClientResponse
    {
        public Guid Id { get; private set; }
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
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public Guid UserId { get; private set; }
        
        public ClientResponse(Guid id, string firstName, string secondName, string firstLastName, string secondLastName, 
            string identificationType, string identification, string email, string address, string phone,
            string cellPhone, bool status, Guid userId)
        {
            Id = id;
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
            CreateAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
            UserId = userId;
        }
    }
}