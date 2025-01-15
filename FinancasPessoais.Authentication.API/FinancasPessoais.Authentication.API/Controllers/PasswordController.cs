using FinancasPessoais.Authentication.API.Controllers.ViewModels;
using FinancasPessoais.Authentication.Application.Commands.Password;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasPessoais.Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly ILogger<PasswordController> _logger;
        private readonly IMediator _mediator;

        public PasswordController(IMediator mediator, ILogger<PasswordController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "RequestPassword")]
        public async Task<IActionResult> RequestPassword([FromBody] RequestPasswordCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid request");
            }

            if (string.IsNullOrEmpty(command.Email))
            {
                return BadRequest("Invalid request");
            }

            try
            {
                var result = _mediator.Send(command).Result;

                var resultViewModel = new RequestPasswordTokenViewModel
                {
                    Token = result.Token,
                    Expiration = result.Expiration
                };

                return Ok(resultViewModel);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
