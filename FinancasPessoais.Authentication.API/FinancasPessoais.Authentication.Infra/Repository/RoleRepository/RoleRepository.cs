using FinancasPessoais.Authentication.Domain.Modules.Roles;
using FinancasPessoais.Authentication.Domain.Modules.Users;
using FinancasPessoais.Authentication.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FinancasPessoais.Authentication.Infra.Repository.RoleRepository
{
    public class RoleRepository(FinancasPessoaisDbContext context) : BaseRepository<User>(context), IRoleRepository
    {
        public async Task<Role> GetByName(string name)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
