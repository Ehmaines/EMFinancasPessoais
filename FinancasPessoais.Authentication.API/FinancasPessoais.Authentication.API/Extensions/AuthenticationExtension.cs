using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FinancasPessoais.Authentication.API.Extensions
{
    public static class AuthenticationExtension
    {
        public static void AddAuthenticationExtension(this WebApplicationBuilder builder)
        {
            var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
            // Adicionar serviços de autenticação
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            // Adicionar serviços de autorização
            builder.Services.AddAuthorization();

        }
    }
}
