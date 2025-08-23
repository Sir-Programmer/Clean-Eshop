using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetById;

public record GetUserByIdQuery(Guid UserId) : IQuery<UserDto?>;