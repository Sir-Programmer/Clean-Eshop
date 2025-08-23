using Common.Query.Filter;

namespace Common.Query;

public class QueryFilter<TResponse, TParam>(TParam filterParamses) : IQuery<TResponse>
    where TResponse : BaseFilter
    where TParam : BaseFilterParam
{
    public TParam FilterParamses { get; set; } = filterParamses;
}