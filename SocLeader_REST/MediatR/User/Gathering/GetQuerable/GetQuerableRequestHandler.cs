using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.Domain.Repositories.Abstract;

namespace SocLeader_REST.MediatR.User.Gathering.GetQuerable
{
    public class GetQuerableRequestHandler : IRequestHandler<GetQuerableRequest, IActionResult>
    {
        private readonly IGatheringRepository _gatheringRepository;

        public GetQuerableRequestHandler(IGatheringRepository gatheringRepository)
        {
            _gatheringRepository = gatheringRepository;
        }

        public async Task<IActionResult> Handle(GetQuerableRequest request, CancellationToken cancellationToken)
        {
            return new OkObjectResult(_gatheringRepository.GetAll().Skip(request.Start).Take(request.Count));
        }
    }
}
