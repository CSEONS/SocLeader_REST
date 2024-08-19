using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Domain.Repositories.Abstract;
using SocLeader_REST.Models;
using SocLeader_REST.Services;

namespace SocLeader_REST.MediatR.User.Gatherings.Update
{
    public class GatheringUpdateRequestHandler : IRequestHandler<GatheringUpdateRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Gathering> _gatheringRepository;
        private readonly IMapper _mapper;

        public GatheringUpdateRequestHandler(UserManager<AppUser> userManager, IRepository<Gathering> gatheringRepository, IMapper mapper)
        {
            _userManager = userManager;
            _gatheringRepository = gatheringRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GatheringUpdateRequest request, CancellationToken cancellationToken)
        {
            var gathering = _gatheringRepository.GetById(request.UpdatingGatheringId);

            if (gathering is null)
                return new BadRequestObjectResult(ActionMessages.GatheringNotFound);

            var user = await _userManager.GetUserAsync(request.User);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound.Message);

            if (user.Id != gathering.Id)
                return new BadRequestObjectResult(ActionMessages.UserNotOwner(user.Id));

            var gatheringViewModel = _mapper.Map<GatheringListViewModel>(gathering);

            return new OkObjectResult(gatheringViewModel);
        }
    }
}
