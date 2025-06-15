using FinancasPessoais.Authentication.Domain.Modules.Token;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasPessoais.Authentication.Application.Commands.Password
{
    public class GetTokenAndHashByUrlCommandHandler : IRequestHandler<GetTokenAndHashByUrlCommand, RequestPasswordToken>
    {
        private readonly IRequestPasswordTokenRepository _requestPasswordTokenRepository;

        public GetTokenAndHashByUrlCommandHandler(IRequestPasswordTokenRepository requestPasswordTokenRepository)
        {
            _requestPasswordTokenRepository = requestPasswordTokenRepository;
        }

        public async Task<RequestPasswordToken> Handle(GetTokenAndHashByUrlCommand request, CancellationToken cancellationToken)
        {
            var requestPasswordToken = await _requestPasswordTokenRepository.GetByUrl(request.TinyUrl);
            return requestPasswordToken;
        }
    }
}
