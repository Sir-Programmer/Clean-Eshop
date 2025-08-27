using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetById;

public record GetUserAddressByIdQuery(Guid AddressId) : IQuery<UserAddressDto?>;