using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Domain.Repositories.Abstract;
using SocLeader_REST.Services;

namespace SocLeader_REST.MediatR.Gatherings.Create
{
    public class GatheringCreateRequestHandler : IRequestHandler<GatheringCreateRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Gathering> _gatheringRepository;
        private readonly IRepository<Tag> _tagsRepository;

        public GatheringCreateRequestHandler(UserManager<AppUser> userManager, IRepository<Gathering> gatheringRepository, IRepository<Tag> tagsRepository)
        {
            _userManager = userManager;
            _gatheringRepository = gatheringRepository;
            _tagsRepository = tagsRepository;

        }

        public async Task<IActionResult> Handle(GatheringCreateRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound.Message);

            var tags = new List<Tag>();

            foreach (var tag in request.Tags)
            {
                Tag? newTag = _tagsRepository
                                .GetAll()
                                .FirstOrDefault(t => t.NormalizedName == tag.ToUpper());

                if (newTag is null)
                {
                    newTag = new Tag()
                    {
                        Id = Guid.NewGuid(),
                        Name = tag,
                        NormalizedName = tag.ToUpper(),
                    };
                    _tagsRepository.Add(newTag);
                    _tagsRepository.SaveChanges();
                    
                    tags.Add(newTag);

                    continue;
                }

                
                tags.Add(newTag);
            }

            var creatingGathering = new Gathering()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Owner = user,
                OwnerId = user.Id,
                Type = request.Type,
                Lat = request.Lat,
                Lon = request.Lon,
                StartTime = DateTime.SpecifyKind(request.StartTime, DateTimeKind.Utc),
                Tags = tags.ToList(),
                Text = request.Text,
            };

            _gatheringRepository.Add(creatingGathering);
            _gatheringRepository.SaveChanges();

            return new OkObjectResult(ActionMessages.GatheringCreated);
        }
    }
}
