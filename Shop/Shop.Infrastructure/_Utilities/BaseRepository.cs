using System.Linq.Expressions;
using Common.Domain;
using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure._Utilities;

public class BaseRepository<TEntity>(ShopContext context) : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ShopContext Context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity?> GetByIdTrackingAsync(Guid id)
    {
        return await _dbSet.AsTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task RemoveAsync(TEntity entity)
    {
        await Task.Run(() => _dbSet.Remove(entity));
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
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
            .AsNoTracking()
            .ToListAsync();

        return (items, totalCount);
    }
}