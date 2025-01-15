namespace FinancasPessoais.Authentication.Domain.Modules.Token
{
    public interface IRequestPasswordTokenRepository
    {
        RequestPasswordToken Create(RequestPasswordToken requestPasswordToken);
        Task<RequestPasswordToken> GetByToken(string token);
    }
}
