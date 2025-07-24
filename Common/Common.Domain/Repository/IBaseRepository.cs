using System.Linq.Expressions;

namespace Common.Domain.Repository;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByIdTrackingAsync(Guid id);

    Task<List<T>> GetAllAsync();

    Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);

    void Update(T entity);

    void Remove(T entity);
    Task RemoveAsync(T entity);

    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    
    Task<(List<T> Items, int TotalCount)> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        bool orderByDescending = false);
}

