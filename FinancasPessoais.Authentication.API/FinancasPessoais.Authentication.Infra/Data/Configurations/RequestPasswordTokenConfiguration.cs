using FinancasPessoais.Authentication.Domain.Modules.Token;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.TinyUrl).HasColumnType("VARCHAR(MAX)").IsRequired();
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.Hash).HasColumnType("VARCHAR(MAX)");
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.UsedAt).HasDefaultValue(null);
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.UserId).HasColumnType("uniqueidentifier").IsRequired();
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<RequestPasswordToken>().Property(x => x.UpdatedAt).HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<RequestPasswordToken>().HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
