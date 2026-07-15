using DeepCore.RequestHandlers;
using DeepCore.RequestHandlers.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DeepCore.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    [Consumes("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateUserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateUserRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPatch("{id}/status")]
        [ProducesResponseType(typeof(PatchUserStatusResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PatchStatus(long id, [FromBody] PatchUserStatusRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List([FromQuery] UserListRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserByIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(long id)
        {
            var request = new GetUserByIdRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
