using Microsoft.EntityFrameworkCore.Storage;
using SocLeader_REST.Domain;
using SocLeader_REST.Services.Interfaces;

namespace SocLeader_REST.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public DatabaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction is null)
                throw new Exception($"{nameof(_transaction)} is null");

            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (_transaction is null)
                throw new Exception($"{nameof(_transaction)} is null");

            await _transaction.RollbackAsync();
        }
    }

}
