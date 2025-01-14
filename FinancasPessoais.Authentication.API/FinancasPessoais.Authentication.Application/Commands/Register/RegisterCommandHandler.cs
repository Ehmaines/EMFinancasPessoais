using FinancasPessoais.Authentication.Application.Commands.Login;
using FinancasPessoais.Authentication.Domain.Common;
using FinancasPessoais.Authentication.Domain.Modules;
using FinancasPessoais.Authentication.Domain.Modules.Roles;
using FinancasPessoais.Authentication.Domain.Modules.Users;
using FinancasPessoais.Authentication.Infra.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinancasPessoais.Authentication.Application.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IGenerateToken _generateToken;
        public RegisterCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository, IGenerateToken generateToken)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _generateToken = generateToken;
        }

        public Task<AuthResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var userRole = _roleRepository.GetByName(Roles.User).Result;
            var user = _userRepository.AddAsync(new User
            {
                Email = command.Email,
                Password = command.Password,
                Name = command.Name,
                RoleId = userRole.Id
            });

            return _generateToken.GenerateUserToken(user.Result);
        }
    }
}
