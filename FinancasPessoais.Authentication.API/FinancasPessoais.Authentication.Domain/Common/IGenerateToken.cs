using FinancasPessoais.Authentication.Application.Commands.Login;
using FinancasPessoais.Authentication.Domain.Modules.Users;
namespace FinancasPessoais.Authentication.Domain.Common
{
    public interface IGenerateToken
    {
        Task<AuthResult> GenerateUserToken(User user);
        Task<PasswordRequestTokenResult> GeneratePasswordRequestToken(User user);
    }
}
