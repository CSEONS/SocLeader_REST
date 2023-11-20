using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.Domain.Repositories.Abstract;
using SocLeader_REST.Services.Managers;

namespace SocLeader_REST.MediatR.Gathering.Create
{
    public class GatheringCreateRequestHandler : IRequestHandler<GatheringCreateRequest, IActionResult>
    {
        private readonly GatheringManager _gatheringManager;
        private readonly IGatheringRepository _gatheringRepository;

        public GatheringCreateRequestHandler(GatheringManager gatheringManager, IGatheringRepository gatheringRepository)
        {
            _gatheringManager = gatheringManager;
            _gatheringRepository = gatheringRepository;

        }

        public async Task<IActionResult> Handle(GatheringCreateRequest request, CancellationToken cancellationToken)
        {
            var newGathering = _gatheringManager.Create
            (
                request.Name, 
                request.StartTime
            );

            await _gatheringRepository.AddAsync(newGathering);
            await _gatheringRepository.SaveAsync();

            return new OkObjectResult(newGathering);
        }
    }
}
