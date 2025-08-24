namespace Common.Query.Filter;

public class BaseFilter
{
    public int EntityCount { get; private set; }
    public int CurrentPage { get; private set; }
    public int PageCount { get; private set; }
    public int StartPage { get; private set; }
    public int EndPage { get; private set; }
    public int Take { get; private set; }

    public void GeneratePaging(int entityCount, int take = 10, int currentPage = 1)
    {
        Take = Math.Max(1, take);
        CurrentPage = Math.Max(1, currentPage);
        EntityCount = Math.Max(0, entityCount);

        PageCount = (int)Math.Ceiling(EntityCount / (double)Take);
        StartPage = Math.Max(1, CurrentPage - 4);
        EndPage = Math.Min(PageCount, CurrentPage + 5);
    }
}

public abstract class BaseFilterParam
{
    public int PageId { get; set; } = 1;
    public int Take { get; set; } = 10;
}

public class BaseFilter<TData, TParam> : BaseFilter where TParam : BaseFilterParam
{
    public IReadOnlyList<TData> Data { get; set; } = [];
    public TParam FilterParams { get; set; } = null!;
}