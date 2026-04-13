using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Interface.Repositories;

namespace top.car.service.Infrastructure.Repositories.Abstractions;

public abstract class Repository<T> :  IRepositoryRead<T>, IRepositoryWrite<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) => await _dbSet.ToListAsync(cancellationToken);

    public virtual async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default) => await _dbSet.FindAsync(new object[] { id }, cancellationToken);

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default) => await _dbSet.AddAsync(entity, cancellationToken);

    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
    public virtual void Dispose()
    {
        _context.Dispose();
    }
}