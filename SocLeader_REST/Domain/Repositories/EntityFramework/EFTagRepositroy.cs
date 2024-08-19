using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Domain.Repositories.Abstract;

namespace SocLeader_REST.Domain.Repositories.EntityFramework
{
    public class EFTagRepositroy : IRepository<Tag>
    {
        private readonly ApplicationDbContext _context;

        public EFTagRepositroy(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Tag entity)
        {
            _context.Add(entity);
        }

        public void Delete(Tag entity)
        {
            _context.Remove(entity);
        }

        public bool Exist(Guid id)
        {
            return _context.Tags.FirstOrDefault(t => t.Id == id) is not null;
        }

        public List<Tag> GetAll()
        {
            return _context.Tags.ToList();
        }

        public Tag GetById(Guid id)
        {
            return _context.Tags.First(t => t.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetById(Guid id, out Tag entity)
        {
            if (Exist(id))
            {
                entity = GetById(id);
                return true;
            }
            else
            {
                entity = Tag.Empty;
                return false;
            }
        }

        public void Update(Tag entity)
        {
            _context.Update(entity);
        }
    }
}
