using Shop.Domain.CommentAgg;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments;

public static class CommentMapper
{
    public static CommentDto? Map(this Comment? comment)
    {
        if (comment == null) return null;
        return new CommentDto()
        {
            Id = comment.Id,
            Text = comment.Text,
            UserId = comment.UserId,
            ProductId = comment.ProductId,
            CreationTime = comment.CreationTime,
            Status = comment.Status,
        };
    }
}