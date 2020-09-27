using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Identity.API.Commands;
using Identity.Domain;

namespace Identity.API.Controllers
{
    [Route("/api")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpPost("/api/auth/register")]
        public async Task<IActionResult> Register(AuthenticateUserCommand command)
        {
            try {
                await _mediator.Send(command);

                return Ok();
            } catch (Exception e) {
                return BadRequest(e.Message);
            };
        }

        [HttpPost("/api/auth/login")]
        public async Task<ActionResult<User>> Login(LoginCommand command)
        {
            try {
                var result = await _mediator.Send(command);

                return Ok(result);
            } catch (Exception e) {
                return BadRequest(e.Message);
            };
        }
    }
}