using FinancasPessoais.Authentication.Domain.Modules.Roles;
using FinancasPessoais.Authentication.Domain.Modules.Token;
using FinancasPessoais.Authentication.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<RequestPasswordToken> GetByToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
