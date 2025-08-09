using X.PagedList;
using X.PagedList.Extensions;

namespace Common.Query.Filter;

public static class PagingExtensions
{
    public static IPagedList<T> ToSafePagedList<T>(this IQueryable<T> query, int pageNumber, int pageSize, int maxPageSize = 30)
    {
        if (pageSize > maxPageSize)
            pageSize = maxPageSize;
        if (pageNumber <= 0)
            pageNumber = 1;
        if (pageSize <= 0)
            pageSize = 1;

        return query.ToPagedList(pageNumber, pageSize);
    }
    
    public static IPagedList<T> ToSafePagedList<T>(this IEnumerable<T> list, int pageNumber, int pageSize, int maxPageSize = 30)
    {
        if (pageSize > maxPageSize)
            pageSize = maxPageSize;
        if (pageNumber <= 0)
            pageNumber = 1;
        if (pageSize <= 0)
            pageSize = 1;

        return list.ToPagedList(pageNumber, pageSize);
    }
}