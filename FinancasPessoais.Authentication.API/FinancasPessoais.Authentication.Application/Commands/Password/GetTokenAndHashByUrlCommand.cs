using FinancasPessoais.Authentication.Domain.Modules.Token;
using MediatR;

namespace FinancasPessoais.Authentication.Application.Commands.Password
{
    public class GetTokenAndHashByUrlCommand : IRequest<RequestPasswordToken>
    {
        public string TinyUrl { get; set; }
    }
}
