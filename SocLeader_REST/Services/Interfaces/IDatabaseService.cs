namespace SocLeader_REST.Services.Interfaces
{
    public interface IDatabaseService
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
