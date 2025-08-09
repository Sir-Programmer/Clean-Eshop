using Common.Query;
using Shop.Domain.CommentAgg.Enums;

namespace Shop.Query.Comments.DTOs;

public class CommentDto : BaseDto
{
    public Guid UserId { get; set; }
    public string UserFullName { get; set; }
    public string Text { get; set; }
    public Guid ProductId { get; set; }
    public string ProductTitle { get; set; }
    public CommentStatus Status { get; set; }
}