using Common.Query;
using Common.Query.Filter;
using Shop.Domain.CommentAgg.Enums;

namespace Shop.Query.Comments.DTOs;

public class CommentFilterParams : BaseFilterParam
{
    public Guid? UserId { get; set; }
    public Guid? ProductId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CommentStatus? CommentStatus { get; set; }
}