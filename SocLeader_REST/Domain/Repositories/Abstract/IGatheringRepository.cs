using SocLeader_REST.Domain.Entities;

namespace SocLeader_REST.Domain.Repositories.Abstract
{
    public interface IGatheringRepository
    {
        Task AddAsync(Gathering gathering);
        void Update(Gathering gathering);
        void Delete(Gathering gathering);
        Gathering? GetById(Guid id);
        IQueryable<Gathering> GetAll();
        Task SaveAsync();
    }
}
