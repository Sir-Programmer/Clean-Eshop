using Common.Application;
using Shop.Domain.CommentAgg.Enums;

namespace Shop.Application.Comments.ChangeStatus;

public record ChangeCommentStatusCommand(Guid CommentId, CommentStatus Status) : IBaseCommand;