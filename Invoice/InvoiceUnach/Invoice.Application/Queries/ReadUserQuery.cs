using Invoice.Application.Dtos.Responses;
using MediatR;

namespace Invoice.Application.Queries
{
    public class ReadUserQuery : IRequest<UserResponse>
    {
        public string Code { get; private set; }
        
        public ReadUserQuery(string code)
        {
            Code = code;
        }
        
    }
}