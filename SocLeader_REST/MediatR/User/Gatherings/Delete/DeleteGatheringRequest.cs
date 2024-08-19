using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace SocLeader_REST.MediatR.User.Gatherings.Delete
{
    public class DeleteGatheringRequest : IRequest<IActionResult>
    {
        public Guid DeletingGatheringRequestId { get; set; }
        [JsonIgnore] public ClaimsPrincipal? User { get; set; }
    }
}
