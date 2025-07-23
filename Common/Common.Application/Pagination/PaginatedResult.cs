namespace Common.Application.Pagination;

public class PaginatedResult<T>
{
    public List<T> Items { get; set; } = [];
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int PageCount { get; set; }
    public int StartPage { get; set; }
    public int EndPage { get; set; }
}
