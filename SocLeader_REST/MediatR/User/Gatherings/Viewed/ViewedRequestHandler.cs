using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Domain.Repositories.Abstract;
using SocLeader_REST.Services;
using SocLeader_REST.Services.Preference;

namespace SocLeader_REST.MediatR.User.Gatherings
{
    public class ViewedRequestHandler : IRequestHandler<ViewedRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEagerRepository<Gathering> _gatheringRepository;
        private readonly IPreferenceChanger _preferenceChanger;

        public ViewedRequestHandler(UserManager<AppUser> userManager, IEagerRepository<Gathering> gatheringRepository, IPreferenceChanger preferenceChanger)
        {
            _userManager = userManager;
            _gatheringRepository = gatheringRepository;
            _preferenceChanger = preferenceChanger;
        }

        public async Task<IActionResult> Handle(ViewedRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound);

            if (_gatheringRepository.Exist(request.GatheringId) is false)
                return new BadRequestObjectResult(ActionMessages.GatheringNotFound);

            var gathering = _gatheringRepository.GetByIdEager(request.GatheringId);

            _preferenceChanger.Change(ref user, gathering.Tags);

            await _userManager.UpdateAsync(user);

            return new OkObjectResult(ActionMessages.Viewed);
        }
    }
}
