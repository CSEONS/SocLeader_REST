using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Domain.Repositories.Abstract;
using SocLeader_REST.Services;

namespace SocLeader_REST.MediatR.User.Gatherings.Follow
{
    public class GatheringFollowRequestHandler : IRequestHandler<GatheringFollowRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Gathering> _gatheringRepository;

        public GatheringFollowRequestHandler(UserManager<AppUser> userManager, IRepository<Gathering> gatheringRepository)
        {
            _userManager = userManager;
            _gatheringRepository = gatheringRepository;
        }
        public async Task<IActionResult> Handle(GatheringFollowRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound);

            if (_gatheringRepository.TryGetById(request.GatheringId, out Gathering gathering) is false)
                return new BadRequestObjectResult(ActionMessages.GatheringNotFound);

            if (gathering?.Id == user.Id)
                return new BadRequestObjectResult(ActionMessages.OwnerCantFollow);

            user  = _userManager.Users.Include(u => u.FollowedGatherings).FirstOrDefault(u => u.Id == user.Id);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound);

            user.FollowedGatherings.Add(gathering);
            
            await _userManager.UpdateAsync(user);

            return new OkObjectResult(ActionMessages.UserFollowed(user.Id, gathering.Id));
        }
    }
}
