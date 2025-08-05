using System.Linq.Expressions;
using Common.Domain;
using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure._Utilities;

public class BaseRepository<TEntity>(ShopContext context) : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ShopContext Context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public Task<TEntity?> GetByIdAsync(Guid id)
    {
        return _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }

    public Task<TEntity?> GetByIdTrackingAsync(Guid id)
    {
        return _dbSet.AsTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        return _dbSet.ToListAsync();
    }

    public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate).ToListAsync();
    }

    public Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.FirstOrDefaultAsync(predicate);
    }

    public Task AddAsync(TEntity entity)
    {
        return _dbSet.AddAsync(entity).AsTask();
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        return _dbSet.AddRangeAsync(entities);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.AnyAsync(predicate);
    }

    public bool Exists(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Any(predicate);
    }

    public async Task<(List<TEntity> Items, int TotalCount)> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool orderByDescending = false)
    {
        var query = _dbSet.AsQueryable();

        if (filter != null)
            query = query.Where(filter);

        var totalCount = await query.CountAsync();

        if (orderBy != null)
        {
            query = orderByDescending
                ? query.OrderByDescending(orderBy)
                : query.OrderBy(orderBy);
        }

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}
