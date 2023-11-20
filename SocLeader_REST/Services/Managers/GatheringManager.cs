using Microsoft.AspNetCore.Identity;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Domain.Repositories.Abstract;

namespace SocLeader_REST.Services.Managers
{
    public class GatheringManager
    {
        private IGatheringRepository _repository;

        public GatheringManager(IGatheringRepository repository)
        {
            _repository = repository;
        }

        public Gathering Create(string name, DateTime startTime)
        {
            Gathering gathering = new Gathering()
            {
                Name = name,
                StartTime = startTime,  
            };

            return gathering;
        }
    }
}
