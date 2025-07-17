using Fluxera.ValueObject;

namespace Shop.Domain.OrderAgg.ValueObjects;

public class OrderAddress(
    string province,
    string city,
    string postalCode,
    string fullName,
    string postalAddress,
    string phoneNumber,
    string nationalId)
    : ValueObject<OrderAddress>
{
    public string Province { get; private set; } = province;
    public string City { get; private set; } = city;
    public string PostalCode { get; private set; } = postalCode;
    public string FullName { get; private set; } = fullName;
    public string PostalAddress { get; private set; } = postalAddress;
    public string PhoneNumber { get; private set; } = phoneNumber;
    public string NationalId { get; private set; } = nationalId;
}