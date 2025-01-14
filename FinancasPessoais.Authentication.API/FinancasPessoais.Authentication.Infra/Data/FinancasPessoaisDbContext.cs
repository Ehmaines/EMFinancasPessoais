using FinancasPessoais.Authentication.Domain.Modules.Roles;
using FinancasPessoais.Authentication.Domain.Modules.Users;
using FinancasPessoais.Authentication.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FinancasPessoais.Authentication.Infra.Data
{
    public class FinancasPessoaisDbContext : DbContext
    {
        public FinancasPessoaisDbContext(DbContextOptions<FinancasPessoaisDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //UserModule
            UserConfiguration.configure(modelBuilder);
            //RoleModule
            RoleConfiguration.configure(modelBuilder);
        }
    }
}
