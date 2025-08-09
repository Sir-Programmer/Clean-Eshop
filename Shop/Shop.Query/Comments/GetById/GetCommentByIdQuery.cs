using Common.Query;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetById;

public record GetCommentByIdQuery(Guid CommentId) : IQuery<CommentDto?>;