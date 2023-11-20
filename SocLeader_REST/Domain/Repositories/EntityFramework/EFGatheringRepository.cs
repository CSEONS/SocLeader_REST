using Microsoft.EntityFrameworkCore;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Domain.Repositories.Abstract;

namespace SocLeader_REST.Domain.Repositories.EntityFramework
{
    public class EFGatheringRepository : IGatheringRepository
    {
        private readonly ApplicationDbContext _context;

        public EFGatheringRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Gathering gathering)
        {
            await _context.Gatherings.AddAsync(gathering);
        }

        public void Delete(Gathering gathering)
        {
            _context.Gatherings.Remove(gathering);
        }

        public IQueryable<Gathering> GetAll()
        {
            return _context.Gatherings;
        }

        public Gathering? GetById(Guid id)
        {
            return _context.Gatherings.FirstOrDefault(g => g.Id == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Gathering gathering)
        {
            _context.Gatherings.Update(gathering);
        }
    }
}
