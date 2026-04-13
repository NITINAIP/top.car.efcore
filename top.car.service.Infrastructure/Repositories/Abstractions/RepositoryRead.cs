using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Interface.Repositories;

namespace top.car.service.Infrastructure.Repositories.Abstractions;

public abstract class RepositoryRead<T> : IRepositoryRead<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public RepositoryRead(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) => await _dbSet.ToListAsync(cancellationToken);

    public virtual async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default) => await _dbSet.FindAsync(new object[] { id }, cancellationToken);

}