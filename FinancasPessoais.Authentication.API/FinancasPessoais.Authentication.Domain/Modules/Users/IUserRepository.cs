using FinancasPessoais.Authentication.Domain.Common;

namespace FinancasPessoais.Authentication.Domain.Modules.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Authenticate(string email, string password);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(Guid id);
        Task<bool> UpdatePassword(User user, string newPassword);
    }
}
