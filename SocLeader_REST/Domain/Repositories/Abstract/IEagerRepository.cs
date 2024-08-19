namespace SocLeader_REST.Domain.Repositories.Abstract
{
    public interface IEagerRepository<T>
    {
        T GetByIdEager(Guid id);
        List<T> GetAllEager();
        bool Exist(Guid id);
    }
}
