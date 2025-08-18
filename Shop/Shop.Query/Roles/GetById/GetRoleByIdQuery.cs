using Common.Query;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetById;

public record GetRoleByIdQuery(Guid RoleId) : IQuery<RoleDto?>;