using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.MediatR.User.Accounts.SignIn;
using SocLeader_REST.MediatR.User.Accounts.SignUp;

namespace SocLeader_REST.Areas.User
{
    [Route("Accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
