using FinancasPessoais.Authentication.Application.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasPessoais.Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator, ILogger<RegisterController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid request");
            }

            if (string.IsNullOrEmpty(command.Email) || string.IsNullOrEmpty(command.Password))
            {
                return BadRequest("Invalid request");
            }

            try
            {
                var result = _mediator.Send(command).Result;

                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
