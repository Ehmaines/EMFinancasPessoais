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

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<bool> UpdatePassword(User user, string newPassword)
        {
            try
            {
                user.Password = newPassword;
                _context.Users.Update(user);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
