namespace Common.Application.Pagination;

public static class PaginationExtensions
{
    public static PaginatedResult<T> ToPaginatedResultAsync<T>(
        this IQueryable<T> query,
        int currentPage,
        int pageSize,
        int pageRange = 9)
    {
        var totalItems = query.Count();
        var pageCount = (int)Math.Ceiling(totalItems / (double)pageSize);

        currentPage = Math.Max(1, Math.Min(currentPage, pageCount));

        var items = query
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var rangeBefore = pageRange / 2;
        var rangeAfter = pageRange - rangeBefore - 1;

        var startPage = Math.Max(1, currentPage - rangeBefore);
        var endPage = Math.Min(pageCount, currentPage + rangeAfter);

        var actualRange = endPage - startPage + 1;
        if (actualRange < pageRange && startPage > 1)
            startPage = Math.Max(1, startPage - (pageRange - actualRange));
        else if (actualRange < pageRange && endPage < pageCount)
            endPage = Math.Min(pageCount, endPage + (pageRange - actualRange));

        return new PaginatedResult<T>
        {
            Items = items,
            CurrentPage = currentPage,
            PageSize = pageSize,
            TotalItems = totalItems,
            PageCount = pageCount,
            StartPage = startPage,
            EndPage = endPage
        };
    }
}
