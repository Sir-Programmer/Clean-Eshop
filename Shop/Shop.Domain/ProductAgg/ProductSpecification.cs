using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.ProductAgg;

public class ProductSpecification : BaseEntity
{
    public ProductSpecification(string key, string value)
    {
        Guard(key, value);
        Key = key;
        Value = value;
    }
    public Guid ProductId { get; internal set; }
    public string Key { get; private set; }
    public string Value { get; private set; }

    private void Guard(string key, string value)
    {
        NullOrEmptyDomainException.CheckString(key, nameof(key));
        NullOrEmptyDomainException.CheckString(value, nameof(value));
    }
}