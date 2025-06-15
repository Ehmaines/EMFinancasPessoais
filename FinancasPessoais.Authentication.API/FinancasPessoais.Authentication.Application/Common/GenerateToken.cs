using FinancasPessoais.Authentication.Application.Commands.Login;
using FinancasPessoais.Authentication.Domain.Common;
using FinancasPessoais.Authentication.Domain.Modules.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinancasPessoais.Authentication.Application.Common
{
    public class GenerateToken : IGenerateToken
    {
        public Task<AuthResult> GenerateUserToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
            var Createdtoken = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.Name),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString())

                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            });

            var token = tokenHandler.WriteToken(Createdtoken);

            return Task.FromResult(new AuthResult
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(2)
            });
        }

        public Task<PasswordRequestTokenResult> GeneratePasswordRequestToken(User user, string tinyUrl)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
            var Createdtoken = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("tinyEmail", tinyUrl+";"+user.Email),
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            });

            var token = tokenHandler.WriteToken(Createdtoken);

            return Task.FromResult(new PasswordRequestTokenResult
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(15)
            });
        }

        public IEnumerable<Claim>? Validate(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            return jwt.Claims;
        }
    }
}
