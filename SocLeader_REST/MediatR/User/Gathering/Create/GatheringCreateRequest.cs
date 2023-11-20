using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SocLeader_REST.MediatR.Gathering.Create
{
    public class GatheringCreateRequest : IRequest<IActionResult>
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
    }
}
