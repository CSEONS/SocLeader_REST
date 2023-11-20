using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.MediatR.Gathering.Create;
using SocLeader_REST.MediatR.User.Gathering.GetQuerable;

namespace SocLeader_REST.Areas.User
{
    [Route("Gatherings")]
    [ApiController]
    public class GatheringController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GatheringController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(GatheringCreateRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<IActionResult> GetQuerable([FromQuery] int start, [FromQuery] int count)
        {
            GetQuerableRequest request = new GetQuerableRequest()
            {
                Start = start,
                Count = count
            };

            return await _mediator.Send(request);
        }
    }
}
