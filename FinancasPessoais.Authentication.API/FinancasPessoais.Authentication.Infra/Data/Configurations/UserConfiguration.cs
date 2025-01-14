using FinancasPessoais.Authentication.Domain.Modules.Users;
using Microsoft.EntityFrameworkCore;

namespace FinancasPessoais.Authentication.Infra.Data.Configurations
{
    public static class UserConfiguration
    {
        public static void configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.Name).HasColumnType("VARCHAR(255)").IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnType("VARCHAR(255)").IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnType("VARCHAR(255)").IsRequired();
            modelBuilder.Entity<User>().Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<User>().Property(x => x.UpdatedAt).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<User>().HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
        }
    }
}
