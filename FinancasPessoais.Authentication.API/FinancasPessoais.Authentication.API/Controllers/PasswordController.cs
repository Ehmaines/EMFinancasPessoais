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

        [HttpGet(Name = "GetTokenAndHash")]
        public async Task<IActionResult> GetTokenAndHash([FromQuery] string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return BadRequest("Invalid request");
            }

            try
            {
                var result = _mediator.Send(new GetTokenAndHashByUrlCommand { TinyUrl = url }).Result;

                if (result == null)
                {
                    return NotFound("Token not found");
                }

                if (result.Expiration < DateTime.UtcNow)
                {
                    return BadRequest("Token expired");
                }
                var resultViewModel = new RequestPasswordTokenViewModel
                {
                    Hash = result.Hash,
                    Expiration = result.Expiration
                };

                return Ok(resultViewModel);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
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
                    Expiration = result.Expiration
                };

                return Ok(resultViewModel);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid request");
            }

            if (string.IsNullOrEmpty(command.Hash) || string.IsNullOrEmpty(command.Password))
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
