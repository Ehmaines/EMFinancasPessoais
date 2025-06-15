namespace FinancasPessoais.Authentication.Domain.Modules.Token
{
    public interface IRequestPasswordTokenRepository
    {
        RequestPasswordToken Create(RequestPasswordToken requestPasswordToken);
        Task<RequestPasswordToken> GetByToken(string token);
        bool ExistsUrl(string tinyUrl);
        Task<RequestPasswordToken> GetByUrl(string tinyUrl);
        Task Update(object requestPasswordToken);
    }
}
