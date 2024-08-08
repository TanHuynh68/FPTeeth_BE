using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using FPTeeth_BE.Database;
using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DatabaseContext _databaseContext;
        private readonly DbSet<T> _set;
        private IDbContextTransaction _transaction;

        public Repository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _set = _databaseContext.Set<T>();
        }

        public IQueryable<T> Get()
        {
            return _set.Where(x => true);
        }

        public async Task<List<T>?> GetValuesAsync(CancellationToken cancellationToken = default)
        {
            return await Get().ToListAsync(cancellationToken);
        }

        public async Task<T?> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            return await Get().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _set.AddRangeAsync(entities, cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _set.AddAsync(entity, cancellationToken);
        }

        public void Update(T entity)
        {
            _set.Update(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _set.RemoveRange(entities);
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }

        public void ClearChangeTracking()
        {
            _databaseContext.ChangeTracker.Clear();
        }

        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }
            _transaction = _databaseContext.Database.BeginTransaction();
        }
    }
}
