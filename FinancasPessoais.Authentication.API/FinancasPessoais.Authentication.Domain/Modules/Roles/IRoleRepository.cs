using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasPessoais.Authentication.Domain.Modules.Roles
{
    public interface IRoleRepository
    {
        Task<Role> GetByName(string name);
    }
}
