using System;

namespace Invoice.Application.Dtos.Responses
{
    public class SubsidiaryResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address{ get; private set; }
        public string Phone1 { get; private set; }
        public string Phone2 { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public Guid UserId { get; private set; }

        public SubsidiaryResponse(Guid id, string name, string address, string phone1, 
            string phone2, Guid userId)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone1 = phone1;
            Phone2 = phone2;
            CreateAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
            UserId = userId;
        }
    }
}