using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SocLeader_REST.MediatR.User.Gatherings.Follow
{
    public class GatheringFollowRequest : IRequest<IActionResult>
    {
        public ClaimsPrincipal? User { get; set; }
        public Guid GatheringId { get; set; }
    }
}
