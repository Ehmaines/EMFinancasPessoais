
using FinancasPessoais.Authentication.Infra.Repository.UserRepository;
using FinancasPessoais.Authentication.Infra.Repository;
using System.Reflection;
using FinancasPessoais.Authentication.Application.Commands.Login;
using FinancasPessoais.Authentication.Domain.Common;
using FinancasPessoais.Authentication.Application.Common;
using FinancasPessoais.Authentication.Domain.Modules.Users;
using FinancasPessoais.Authentication.Domain.Modules.Roles;
using FinancasPessoais.Authentication.Infra.Repository.RoleRepository;
using FinancasPessoais.Authentication.Domain.Modules.Token;
using FinancasPessoais.Authentication.Infra.Repository.RequestPasswordTokenRepository;
using FinancasPessoais.Authentication.Domain.Email;
using FinancasPessoais.Authentication.Application.Email;

namespace FinancasPessoais.Authentication.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjectionExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient<IRoleRepository, RoleRepository>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IGenerateToken, GenerateToken>();
            builder.Services.AddTransient<IRequestPasswordTokenRepository, RequestPasswordTokenRepository>();
            builder.Services.AddTransient<IEmailService, EmailService>();

            builder.AddMediatR();
        }

        private static void AddMediatR(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            var applicationAssembly = Assembly.GetAssembly(typeof(LoginCommandHandler));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly!));
        }
    }
}
