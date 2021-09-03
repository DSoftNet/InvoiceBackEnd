
namespace Invoice.Application.Dtos.Responses
{
    public class ItemCatalogResponse
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Value { get; private set; }
        public string Description { get; private set; }
        public bool Status { get; private set; }
        public string CodeCatalog { get; private set; }
        
        public ItemCatalogResponse(string name, string code, string value, string description, bool status, string codeCatalog)
        {
            Name = name;
            Code = code;
            Value = value;
            Description = description;
            Status = status;
            CodeCatalog = codeCatalog;
        }
    }
}