namespace SocLeader_REST.Domain.Repositories.Abstract
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(Guid id);
        List<T> GetAll();
        bool Exist(Guid id);
        bool TryGetById(Guid id, out T entity);
        void SaveChanges();
    }
}
