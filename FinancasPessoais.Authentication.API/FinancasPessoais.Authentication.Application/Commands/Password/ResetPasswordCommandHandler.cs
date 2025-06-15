using FinancasPessoais.Authentication.Application.Common;
using FinancasPessoais.Authentication.Domain.Common;
using FinancasPessoais.Authentication.Domain.Modules.Token;
using FinancasPessoais.Authentication.Domain.Modules.Users;
using MediatR;

namespace FinancasPessoais.Authentication.Application.Commands.Password
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IRequestPasswordTokenRepository _requestPasswordTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGenerateToken _generateToken;
        public ResetPasswordCommandHandler(IRequestPasswordTokenRepository requestPasswordTokenRepository,IUserRepository userRepository, IGenerateToken generateToken)
        {
            _requestPasswordTokenRepository = requestPasswordTokenRepository;
            _userRepository = userRepository;
            _generateToken = generateToken;
        }

        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var token = Cryptography.Decrypt(request.Hash);
            var claimsPrincipal = _generateToken.Validate(token);

            var tinyEmail = claimsPrincipal.FirstOrDefault(c => c.Type == "tinyEmail").Value;
            var splitted = tinyEmail.Split(';');
            var tinyUrl = splitted[0];
            var email = splitted[1];
            var requestPasswordToken = await _requestPasswordTokenRepository.GetByUrl(tinyUrl);

            var user = await _userRepository.GetByIdAsync(requestPasswordToken.UserId);
            if(RequestPasswordTokenGuard(requestPasswordToken, user, email)){
                throw new UnauthorizedAccessException("Invalid or expired password reset token.");
            }

            if (user == null) throw new KeyNotFoundException("User not found");

            return await _userRepository.UpdatePassword(user, request.Password);
        }

        private bool RequestPasswordTokenGuard(RequestPasswordToken requestPasswordToken, User user, string email)
        {
            if (requestPasswordToken is null || requestPasswordToken.Expiration < DateTime.UtcNow || user.Email != email)
            {
                return true;
            }
            return false;
        }
    }
}
