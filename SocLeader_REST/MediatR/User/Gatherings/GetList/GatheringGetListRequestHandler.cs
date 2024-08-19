using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Domain.Repositories.Abstract;
using SocLeader_REST.Models;

namespace SocLeader_REST.MediatR.User.Gatherings.GetList
{
    public class GatheringGetListRequestHandler : IRequestHandler<GatheringGetListRequest, IActionResult>
    {
        private readonly IRepository<Gathering> _gatheringRepository;
        private readonly IMapper _mapper;

        public GatheringGetListRequestHandler(IRepository<Gathering> gatheringRepository, IMapper mapper)
        {
            _gatheringRepository = gatheringRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GatheringGetListRequest request, CancellationToken cancellationToken)
        {
            var gatherings = _gatheringRepository
                                .GetAll()
                                .Skip(request.Start)
                                .Take(request.Count);

            var gatheringsViewModel = _mapper.Map<IEnumerable<GatheringListViewModel>>(gatherings);

            return new OkObjectResult(gatheringsViewModel);
        }
    }
}
