using Common.Application;

namespace Shop.Application.Users.AddAddress;

public record AddUserAddressCommand(Guid UserId, string Province, string City, string PostalCode, string FullName, string PostalAddress,
    string PhoneNumber, string NationalId) : IBaseCommand;