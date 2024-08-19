using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Domain.Repositories.Abstract;

namespace SocLeader_REST.Domain.Repositories.EntityFramework
{
    public class EFGatheringRepository : IRepository<Gathering>, IEagerRepository<Gathering>
    {
        private readonly ApplicationDbContext _context;

        public EFGatheringRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Gathering entity)
            {
            _context.Add(entity);
        }

        public void Delete(Gathering entity)
        {
            _context.Remove(entity);
        }

        public bool Exist(Guid id)
        {
            return _context.Gatherings.FirstOrDefault(x => x.Id == id) is not null;
        }

        public List<Gathering> GetAll()
        {
            return _context.Gatherings.ToList();
        }

        public List<Gathering> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Gathering GetById(Guid id)
        {
            return _context.Gatherings.First(g => g.Id == id);
        }

        public Gathering GetByIdEager(Guid id)
        {
            return _context.Gatherings.Include(g => g.Tags).First(g => g.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetById(Guid id, out Gathering entity)
        {
            if (Exist(id))
            {
                entity = GetById(id);
                return true;
            }
            else
            {
                entity = Gathering.Empty;
                return false;
            }
        }

        public void Update(Gathering entity)
        {
            _context.Gatherings.Update(entity);
        }
    }
}
