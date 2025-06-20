﻿using FinancasPessoais.Authentication.Domain.Modules.Token;
using MediatR;

namespace FinancasPessoais.Authentication.Application.Commands.Password
{
    public class RequestPasswordCommand: IRequest<RequestPasswordToken>
    {
        public string Email { get; set; }
    }
}
