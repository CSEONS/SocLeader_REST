using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Domain.Repositories.Abstract;
using SocLeader_REST.Models;
using SocLeader_REST.Services;

namespace SocLeader_REST.MediatR.User.Gatherings.GetMyGatherings
{
    public class GetMyGatheringsRequestHandler : IRequestHandler<GetMyGatheringsRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GetMyGatheringsRequestHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetMyGatheringsRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound);

            var userGatherings = _userManager
                                    .Users
                                    .Include(u => u.CreatedGatherings)
                                    .FirstOrDefault(u => u.Id == user.Id)?
                                    .CreatedGatherings;

            var viewModel = _mapper.Map<List<GatheringListViewModel>>(userGatherings);

            return new OkObjectResult(viewModel);
        }
    }
}
