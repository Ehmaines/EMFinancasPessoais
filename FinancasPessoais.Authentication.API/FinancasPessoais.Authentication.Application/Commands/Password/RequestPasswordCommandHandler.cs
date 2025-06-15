using FinancasPessoais.Authentication.Application.Common;
using FinancasPessoais.Authentication.Domain.Common;
using FinancasPessoais.Authentication.Domain.Email;
using FinancasPessoais.Authentication.Domain.Modules.Token;
using FinancasPessoais.Authentication.Domain.Modules.Users;
using MediatR;

namespace FinancasPessoais.Authentication.Application.Commands.Password
{
    public class RequestPasswordCommandHandler : IRequestHandler<RequestPasswordCommand, RequestPasswordToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenerateToken _generateToken;
        private readonly IRequestPasswordTokenRepository _requestPasswordTokenRepository;
        private readonly IEmailService _emailService;
        public RequestPasswordCommandHandler(IUserRepository userRepository, IGenerateToken generateToken, IRequestPasswordTokenRepository requestPasswordTokenRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _generateToken = generateToken;
            _requestPasswordTokenRepository = requestPasswordTokenRepository;
            _emailService = emailService;
        }

        public Task<RequestPasswordToken> Handle(RequestPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetByEmailAsync(request.Email).Result;
            if (user is null)
            {
                return Task.FromResult<RequestPasswordToken>(null);
            }
            var tinyUrl = TinyUrlGenerator.GenerateUnique(_requestPasswordTokenRepository);
            var token = _generateToken.GeneratePasswordRequestToken(user, tinyUrl).Result;
            var hash = Cryptography.Encrypt(token.Token);
            var tokenCreated = _requestPasswordTokenRepository.Create(new RequestPasswordToken
            {
                Hash = hash,
                UserId = user.Id,
                Expiration = token.Expiration,
                TinyUrl = tinyUrl,
            });

            _emailService.SendEmailAsync(user, tinyUrl, token.Expiration);

            return Task.FromResult<RequestPasswordToken>(tokenCreated);
        }
    }
}
