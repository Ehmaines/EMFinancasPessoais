namespace FinancasPessoais.Authentication.Domain.Common
{
    public class PasswordRequestTokenResult
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool AlreadyUsed { get; set; }
    }
}
