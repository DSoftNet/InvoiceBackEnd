using MediatR;

namespace Invoice.Application.Commands
{
    public class CreateCatalogCommand : IRequest<bool>
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public string Value { get; private set; }
        public bool Status { get; private set; }

        public CreateCatalogCommand(string name, string code, string description, string value, bool status)
        {
            Name = name;
            Code = code;
            Description = description;
            Value = value;
            Status = status;
        }
    }
}