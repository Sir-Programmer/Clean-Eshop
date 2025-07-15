using MediatR;

namespace Common.Domain;

public class BaseDomainEvent : INotification
{
    public DateTime CreationTime { get; set; } = DateTime.Now;
}