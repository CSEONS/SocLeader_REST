using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SocLeader_REST.Areas.Admin
{
    [Route("Admin/Accounts")]
    [ApiController]
    public class AdminAccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
