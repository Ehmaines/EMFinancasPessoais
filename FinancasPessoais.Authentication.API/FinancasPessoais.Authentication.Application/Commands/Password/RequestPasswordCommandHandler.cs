using FinancasPessoais.Authentication.Application.Commands.Login;
using FinancasPessoais.Authentication.Domain.Common;
using FinancasPessoais.Authentication.Domain.Modules.Token;
using FinancasPessoais.Authentication.Domain.Modules.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasPessoais.Authentication.Application.Commands.Password
{
    public class RequestPasswordCommandHandler : IRequestHandler<RequestPasswordCommand, RequestPasswordToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenerateToken _generateToken;
        private readonly IRequestPasswordTokenRepository _requestPasswordTokenRepository;
        public RequestPasswordCommandHandler(IUserRepository userRepository, IGenerateToken generateToken, IRequestPasswordTokenRepository requestPasswordTokenRepository)
        {
            _userRepository = userRepository;
            _generateToken = generateToken;
            _requestPasswordTokenRepository = requestPasswordTokenRepository;
        }

        public Task<RequestPasswordToken> Handle(RequestPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetByEmailAsync(request.Email).Result;
            if (user is null)
            {
                return Task.FromResult<RequestPasswordToken>(null);
            }
            var token = _generateToken.GeneratePasswordRequestToken(user).Result;

            var tokenCreated = _requestPasswordTokenRepository.Create(new RequestPasswordToken
            {
                Token = token.Token,
                UserId = user.Id,
                Expiration = token.Expiration
            });

            return Task.FromResult<RequestPasswordToken>(tokenCreated);
        }
    }
}
