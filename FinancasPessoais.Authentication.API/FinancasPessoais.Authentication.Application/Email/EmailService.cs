using FinancasPessoais.Authentication.Domain.Email;
using FinancasPessoais.Authentication.Domain.Modules.Users;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Text;

namespace FinancasPessoais.Authentication.Application.Email
{

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(User user, string tinyUrl, DateTime tokenExpiration)
        {
            try
            {
                var apiUrl = _configuration["ApiUrl"];
                var sender = Environment.GetEnvironmentVariable("EML");

                MailMessage mail = new MailMessage(sender, user.Email);
                mail.Subject = "Recuperação de senha";
                mail.IsBodyHtml = true;
                mail.Body = $"<h1>Recuperação de senha</h1><p>Olá {user.Name} <br> Clique no link para recuperar sua senha: <a href='{apiUrl}password/?url={tinyUrl}'>Recuperar senha</a></p><br><br><p>O Token irá expirar em 15 minutos";
                mail.SubjectEncoding = Encoding.UTF8;
                mail.BodyEncoding = Encoding.UTF8;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(sender, Environment.GetEnvironmentVariable("EML_P"));

                smtp.EnableSsl = true;

                smtp.Send(mail);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
