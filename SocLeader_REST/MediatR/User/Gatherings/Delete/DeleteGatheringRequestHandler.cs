using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Domain.Repositories.Abstract;
using SocLeader_REST.Services;

namespace SocLeader_REST.MediatR.User.Gatherings.Delete
{
    public class DeleteGatheringRequestHandler : IRequestHandler<DeleteGatheringRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Gathering> _gatheringRepository;

        public DeleteGatheringRequestHandler(UserManager<AppUser> userManager, IRepository<Gathering> gatheringRepository)
        {
            _userManager = userManager;
            _gatheringRepository = gatheringRepository;
        }

        public async Task<IActionResult> Handle(DeleteGatheringRequest request, CancellationToken cancellationToken)
        {
            if (_gatheringRepository.TryGetById(request.DeletingGatheringRequestId, out Gathering deletingGathering))
                return new BadRequestObjectResult(ActionMessages.GatheringNotFound.Message);

            var user = await _userManager.GetUserAsync(request.User);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound);

            if (user.Id != deletingGathering.Id)
                return new BadRequestObjectResult(ActionMessages.UserNotOwner(user.Id));

            _gatheringRepository.Delete(deletingGathering);

            return new OkObjectResult(ActionMessages.GatheringDeleted);
        }
    }
}
