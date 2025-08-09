namespace Common.Query;

public class BaseFilter
{
    public int EntityCount { get; private set; }
    public int CurrentPage { get; private set; }
    public int PageCount { get; private set; }
    public int StartPage { get; private set; }
    public int EndPage { get; private set; }
    public int Take { get; private set; }

    public void GeneratePaging(int entityCount, int take, int currentPage)
    {
        if (take <= 0) take = 10;
        if (currentPage <= 0) currentPage = 1;

        EntityCount = entityCount;
        Take = take;
        CurrentPage = currentPage;

        PageCount = (int)Math.Ceiling(entityCount / (double)take);
        StartPage = Math.Max(1, currentPage - 4);
        EndPage = Math.Min(PageCount, currentPage + 5);
    }

    public void GeneratePaging(IQueryable<object> data, int take, int currentPage)
    {
        var count = data?.Count() ?? 0;
        GeneratePaging(count, take, currentPage);
    }
}

public abstract class BaseFilterParam
{
    public int PageId { get; set; } = 1;
    public int Take { get; set; } = 10;
}

public class BaseFilter<TData, TParam> : BaseFilter
    where TParam : BaseFilterParam
{
    public List<TData> Data { get; set; }
    public TParam FilterParams { get; set; }
}