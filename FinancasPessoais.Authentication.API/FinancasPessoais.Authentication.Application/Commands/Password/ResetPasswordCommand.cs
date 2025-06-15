using MediatR;

namespace FinancasPessoais.Authentication.Application.Commands.Password
{
    public class ResetPasswordCommand: IRequest<bool>
    {
        public string Hash { get; set; }
        public string Password { get; set; }
    }
}
