using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SocLeader_REST.MediatR.User.Gatherings.GetList
{
    public class GatheringGetListRequest : IRequest<IActionResult>
    {
        public int Start { get; set; }
        public int Count { get; set; }
    }
}
