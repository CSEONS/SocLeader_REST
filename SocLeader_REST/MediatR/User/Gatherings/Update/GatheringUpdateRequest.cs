using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace SocLeader_REST.MediatR.User.Gatherings.Update
{
    public class GatheringUpdateRequest : IRequest<IActionResult>
    {
        [JsonIgnore] public Guid UpdatingGatheringId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime StartTime { get; set; }
        [JsonIgnore] public ClaimsPrincipal? User { get; internal set; }
    }
}
