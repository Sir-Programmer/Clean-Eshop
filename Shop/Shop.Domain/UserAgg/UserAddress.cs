using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAgg;

public class UserAddress : BaseEntity
{
    public UserAddress(string province, string city, string postalCode, string fullName, string postalAddress,
        string phoneNumber, string nationalId, bool isActive)
    {
        Guard(province, city, postalCode, fullName, postalAddress, phoneNumber, nationalId);
        Province = province;
        City = city;
        PostalCode = postalCode;
        FullName = fullName;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        NationalId = nationalId;
        IsActive = isActive;
    }

    public Guid UserId { get; private set; }
    public string Province { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string FullName { get; private set; }
    public string PostalAddress { get; private set; }
    public string PhoneNumber { get; private set; }
    public string NationalId { get; private set; }
    public bool IsActive { get; private set; }

    public void Edit(string province, string city, string postalCode, string fullName, string postalAddress,
        string phoneNumber, string nationalId)
    {
        Guard(province, city, postalCode, fullName, postalAddress, phoneNumber, nationalId);
        Province = province;
        City = city;
        PostalCode = postalCode;
        FullName = fullName;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        NationalId = nationalId;
    }

    public void SetActive()
    {
        IsActive = true;
    }
    
    public void SetDeActive()
    {
        IsActive = false;
    }

    private void Guard(string province, string city, string postalCode, string fullName, string postalAddress,
        string phoneNumber, string nationalId)
    {
        NullOrEmptyDomainException.CheckString(province, nameof(province));
        NullOrEmptyDomainException.CheckString(city, nameof(city));
        NullOrEmptyDomainException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainException.CheckString(fullName, nameof(fullName));
        NullOrEmptyDomainException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmptyDomainException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmptyDomainException.CheckString(nationalId, nameof(nationalId));
        if (!nationalId.IsValidIranianNationalId())
            throw new InvalidDomainDataException("کد ملی نامعتبر است");
        if (!phoneNumber.IsValidIranianPhoneNumber())
            throw new InvalidDomainDataException("شماره موبایل نامعتبر است");
    }
}