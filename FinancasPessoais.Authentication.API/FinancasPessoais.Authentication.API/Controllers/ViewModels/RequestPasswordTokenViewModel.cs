namespace FinancasPessoais.Authentication.API.Controllers.ViewModels
{
    public class RequestPasswordTokenViewModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
