using MediatR;

namespace Invoice.Domain.Services.Validations
{
    public class ValidateProductService : IRequest<bool>
    {
        public string Code { get; private set; }

        public ValidateProductService(string code)
        {
            Code = code;
        }
    }
}