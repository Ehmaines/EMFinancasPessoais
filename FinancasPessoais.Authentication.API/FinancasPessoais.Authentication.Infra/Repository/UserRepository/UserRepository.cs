using FinancasPessoais.Authentication.Domain.Modules.Users;
using FinancasPessoais.Authentication.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FinancasPessoais.Authentication.Infra.Repository.UserRepository
{
    public class UserRepository(FinancasPessoaisDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User> Authenticate(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
