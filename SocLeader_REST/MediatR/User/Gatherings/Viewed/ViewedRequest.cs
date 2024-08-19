using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SocLeader_REST.MediatR.User.Gatherings
{
    public class ViewedRequest : IRequest<IActionResult>
    {
        public Guid GatheringId { get; set; }
        public ClaimsPrincipal? User;
    }
}
