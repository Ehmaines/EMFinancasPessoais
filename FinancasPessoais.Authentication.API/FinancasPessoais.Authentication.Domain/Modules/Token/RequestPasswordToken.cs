using FinancasPessoais.Authentication.Domain.Modules.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasPessoais.Authentication.Domain.Modules.Token
{
    public class RequestPasswordToken : BaseModule
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool AlreadyUsed { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
