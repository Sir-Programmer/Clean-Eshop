using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.ProductAgg;

public class ProductImage : BaseEntity
{
    public ProductImage(string imageName, int sequence)
    {
        Guard(imageName);
        ImageName = imageName;
        Sequence = sequence;
    }
    public string ImageName { get; private set; }
    public Guid ProductId { get; internal set; }
    public int Sequence { get; private set; }

    internal void SetSequence(int sequence)
    {
        Sequence = sequence;
    }

    private void Guard(string imageName)
    {
        NullOrEmptyDomainException.CheckString(imageName, nameof(imageName));
    }
}