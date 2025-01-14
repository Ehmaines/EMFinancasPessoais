namespace FinancasPessoais.Authentication.Application.Commands.Login
{
    public class AuthResult
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
