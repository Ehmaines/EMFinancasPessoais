namespace FinancasPessoais.Authentication.API.Controllers.ViewModels
{
    public class RequestPasswordTokenViewModel
    {
        public string Hash { get; set; }
        public DateTime Expiration { get; set; }
    }
}
