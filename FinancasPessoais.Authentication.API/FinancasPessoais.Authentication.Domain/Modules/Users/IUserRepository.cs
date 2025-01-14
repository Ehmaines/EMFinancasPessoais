using FinancasPessoais.Authentication.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasPessoais.Authentication.Domain.Modules.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Authenticate(string email, string password);
    }
}
