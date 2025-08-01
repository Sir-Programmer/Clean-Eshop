using Common.Application;

namespace Shop.Application.Users.EditAddress;

public record EditUserAddressCommand(Guid UserId, Guid AddressId, string Province, string City, string PostalCode, string FullName, string PostalAddress,
    string PhoneNumber, string NationalId) : IBaseCommand;