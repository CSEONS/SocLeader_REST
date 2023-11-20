using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SocLeader_REST.MediatR.User.Gathering.GetQuerable
{
    public class GetQuerableRequest : IRequest<IActionResult>
    {
        public int Start { get; set; }
        public int Count { get; set; }
    }
}
