using Common.Query;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter;

public class GetCommentByFilterQuery(CommentFilterParams filterParams)
    : QueryFilter<CommentFilterResult, CommentFilterParams>(filterParams)
{
}