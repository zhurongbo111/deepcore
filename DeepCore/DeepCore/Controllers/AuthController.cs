using DeepCore.RequestHandlers;
using DeepCore.RequestHandlers.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DeepCore.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    [Consumes("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthLoginResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] AuthLoginRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPost("me")]
        [ProducesResponseType(typeof(AuthMeResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Me([FromBody] AuthMeRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPut("password")]
        [ProducesResponseType(typeof(AuthPasswordChangeResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePassword([FromBody] AuthPasswordChangeRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
