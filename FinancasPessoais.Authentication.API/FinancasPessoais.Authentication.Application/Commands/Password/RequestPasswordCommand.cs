using FinancasPessoais.Authentication.Domain.Modules.Token;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasPessoais.Authentication.Application.Commands.Password
{
    public class RequestPasswordCommand: IRequest<RequestPasswordToken>
    {
        public string Email { get; set; }
    }
}
