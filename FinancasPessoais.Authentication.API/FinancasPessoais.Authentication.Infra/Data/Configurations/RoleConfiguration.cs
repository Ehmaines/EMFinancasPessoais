using FinancasPessoais.Authentication.Domain.Modules.Roles;
using Microsoft.EntityFrameworkCore;

namespace FinancasPessoais.Authentication.Infra.Data.Configurations
{
    public static class RoleConfiguration
    {
        public static void configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Role>().HasKey(x => x.Id);
            modelBuilder.Entity<Role>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Role>().Property(x => x.Name).HasColumnType("VARCHAR(255)").IsRequired();
        }
    }
}
