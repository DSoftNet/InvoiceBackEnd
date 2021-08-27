using System;

namespace Invoice.Application.Dtos.Responses
{
    public class CatalogResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Value { get; private set; }
        public string Description { get; private set; }
        public bool Status { get; private set; }
        
        public CatalogResponse(Guid id, string name, string code, string value, 
            string description, bool status)
        {
            Id = id;
            Name = name;
            Code = code;
            Value = value;
            Description = description;
            Status = status;
        } 
    }
}