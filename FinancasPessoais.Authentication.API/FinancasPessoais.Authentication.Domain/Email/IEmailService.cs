using FinancasPessoais.Authentication.Domain.Modules.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasPessoais.Authentication.Domain.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(User user , string token, DateTime expiration);
    }
}
