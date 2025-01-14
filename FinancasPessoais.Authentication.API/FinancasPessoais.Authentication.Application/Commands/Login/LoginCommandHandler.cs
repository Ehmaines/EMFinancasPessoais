using FinancasPessoais.Authentication.Infra.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FinancasPessoais.Authentication.Domain.Common;
using FinancasPessoais.Authentication.Domain.Modules.Users;

namespace FinancasPessoais.Authentication.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenerateToken _generateToken;
        public LoginCommandHandler(IUserRepository userRepository, IGenerateToken generateToken)
        {
            _userRepository = userRepository;
            _generateToken = generateToken;
        }

        public Task<AuthResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Authenticate(request.Email, request.Password).Result;
            if (user is null)
            {
                return Task.FromResult<AuthResult>(null);
            }

            return _generateToken.GenerateUserToken(user);
        }
    }
}
