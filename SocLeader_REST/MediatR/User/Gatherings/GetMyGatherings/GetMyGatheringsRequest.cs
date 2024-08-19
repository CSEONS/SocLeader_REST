using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SocLeader_REST.MediatR.User.Gatherings.GetMyGatherings
{
    public class GetMyGatheringsRequest : IRequest<IActionResult>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
