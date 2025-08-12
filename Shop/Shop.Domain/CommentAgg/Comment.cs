using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.CommentAgg.Enums;

namespace Shop.Domain.CommentAgg;

public class Comment : AggregateRoot
{
    private Comment()
    {
        
    }
    public Comment(Guid userId, string text, Guid productId)
    {
        Guard(text);
        UserId = userId;
        Text = text;
        ProductId = productId;
        Status = CommentStatus.Pending;
    }
    public Guid UserId { get; private set; }
    public string Text { get; private set; }
    public Guid ProductId { get; private set; }
    public CommentStatus Status { get; private set; }
    public DateTime LastUpdate { get; private set; }

    public void Edit(string text)
    {
        Guard(text);
        Text = text;
        Status = CommentStatus.Pending;
    }

    public void ChangeStatus(CommentStatus status)
    {
        Status = status;
        LastUpdate = DateTime.Now;
    }

    private void Guard(string text)
    {
        NullOrEmptyDomainException.CheckString(text, nameof(text));
    }
}