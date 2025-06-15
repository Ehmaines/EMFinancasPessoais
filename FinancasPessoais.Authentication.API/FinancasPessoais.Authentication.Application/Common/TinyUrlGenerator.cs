using FinancasPessoais.Authentication.Domain.Modules.Token;
using System.Text;

namespace FinancasPessoais.Authentication.Application.Common
{
    public static class TinyUrlGenerator
    {
        private const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random Random = new Random();

        public static string GenerateUnique(IRequestPasswordTokenRepository requestPasswordTokenRepository, int length = 6)
        {
            string code;
            do
            {
                code = Generate(length);
            } while (requestPasswordTokenRepository.ExistsUrl(code));

            return code;
        }

        private static string Generate(int length)
        {
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                result.Append(AllowedChars[Random.Next(AllowedChars.Length)]);
            return result.ToString();
        }
    }
}
