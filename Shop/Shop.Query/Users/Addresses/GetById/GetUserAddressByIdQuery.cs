using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetById;

public record GetUserAddressByIdQuery(Guid AddressId) : IQuery<UserAddressDto?>;