using FinancasPessoais.Authentication.Domain.Modules.Roles;
using FinancasPessoais.Authentication.Domain.Modules.Token;
using FinancasPessoais.Authentication.Domain.Modules.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasPessoais.Authentication.Infra.Data.Configurations
{
    public static class RequestPasswordTokenConfiguration
    {
        public static void configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestPasswordToken>().ToTable("RequestPasswordTokens");
            modelBuilder.Entity<RequestPasswordToken>().HasKey(x => x.Id);
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.Expiration).IsRequired();
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.Token).HasColumnType("VARCHAR(MAX)").IsRequired();
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.AlreadyUsed).HasDefaultValue(false).IsRequired();
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.UserId).HasColumnType("uniqueidentifier").IsRequired();
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.UpdatedAt).HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<RequestPasswordToken>().HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
