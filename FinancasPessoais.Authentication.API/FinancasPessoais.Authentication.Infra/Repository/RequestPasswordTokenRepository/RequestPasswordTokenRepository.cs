using FinancasPessoais.Authentication.Domain.Modules.Roles;
using FinancasPessoais.Authentication.Domain.Modules.Token;
using FinancasPessoais.Authentication.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FinancasPessoais.Authentication.Infra.Repository.RequestPasswordTokenRepository
{
    public class RequestPasswordTokenRepository(FinancasPessoaisDbContext context) : BaseRepository<Role>(context), IRequestPasswordTokenRepository
    {
        public RequestPasswordToken Create(RequestPasswordToken requestPasswordToken)
        {
            var useradded = context.Add(requestPasswordToken);
            context.SaveChanges();
            return useradded.Entity;
        }

        public bool ExistsUrl(string tinyUrl)
        {
            return context.RequestPasswordTokens.Any(x => x.TinyUrl == tinyUrl);
        }

        public Task<RequestPasswordToken> GetByUrl(string tinyUrl)
        {
            return context.RequestPasswordTokens.FirstOrDefaultAsync(x => x.TinyUrl == tinyUrl);
        }

        public Task Update(object requestPasswordToken)
        {
            return null;
        }

        public Task<RequestPasswordToken> GetByToken(string token)
        {
            throw new NotImplementedException();
        }

    }
}
