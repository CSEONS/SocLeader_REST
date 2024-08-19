using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.MediatR.Gatherings.Create;
using SocLeader_REST.MediatR.User.Gatherings.Delete;
using SocLeader_REST.MediatR.User.Gatherings.Follow;
using SocLeader_REST.MediatR.User.Gatherings.GetMyGatherings;
using SocLeader_REST.MediatR.User.Gatherings.GetList;
using SocLeader_REST.MediatR.User.Gatherings.Update;
using SocLeader_REST.MediatR.User.Gatherings;

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
        public async Task<IActionResult> Create([FromForm] GatheringCreateRequest request)
        {
            request.User = User;
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int start, [FromQuery] int count)
        {
            GatheringGetListRequest request = new GatheringGetListRequest()
            {
                Start = start,
                Count = count
            };

            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] GatheringUpdateRequest request)
        {
            request.UpdatingGatheringId = id;
            request.User = User;

            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            DeleteGatheringRequest request = new DeleteGatheringRequest()
            {
                DeletingGatheringRequestId = id,
                User = User
            };

            return await _mediator.Send(request);
        }

        [HttpPost("Follow")]
        public async Task<IActionResult> Follow([FromQuery] Guid id)
        {
            GatheringFollowRequest request = new GatheringFollowRequest()
            {
                User = User,
                GatheringId = id,
            };

            return await _mediator.Send(request);
        }

        [HttpGet("My")]
        public async Task<IActionResult> GetMyGatherings()
        {
            GetMyGatheringsRequest request = new()
            {
                User = User
            };

            return await _mediator.Send(request);
        }

        [HttpPost("Viewed")]
        public async Task<IActionResult> Viewed(ViewedRequest request)
        {
            request.User = User;

            return await _mediator.Send(request);
        }
    }
}
