using FinancasPessoais.Authentication.Domain.Modules.Users;

namespace FinancasPessoais.Authentication.Domain.Modules.Token
{
    public class RequestPasswordToken : BaseModule
    {
        public string TinyUrl { get; set; }
        public string Hash { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime UsedAt { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
