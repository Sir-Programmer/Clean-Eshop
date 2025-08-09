namespace Common.Query;

public static class QueryableExtensions
{
    public static TFilterResult ToPagedResult<TEntity, TData, TParam, TFilterResult>(
        this IQueryable<TEntity> query,
        TParam filterParams,
        Func<TEntity, TData> selector
    )
        where TParam : BaseFilterParam
        where TFilterResult : BaseFilter<TData, TParam>, new()
    {
        var skip = (filterParams.PageId - 1) * filterParams.Take;

        var data = query
            .Skip(skip)
            .Take(filterParams.Take).AsEnumerable()
            .Select(selector)
            .ToList();

        var result = new TFilterResult
        {
            Data = data,
            FilterParams = filterParams
        };

        result.GeneratePaging(query.Cast<object>(), filterParams.Take, filterParams.PageId);
        return result;
    }
}