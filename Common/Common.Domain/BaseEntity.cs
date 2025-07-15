namespace Common.Domain;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; } = new();
}