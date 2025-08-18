﻿using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Enums;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles;

public static class RoleMapper
{
    public static RoleDto? Map(this Role? role)
    {
        if  (role == null) return null;
        return new RoleDto()
        {
            Title = role.Title,
            Permissions = role.Permissions.Select(r => r.Permission).ToList()
        };
    }
}