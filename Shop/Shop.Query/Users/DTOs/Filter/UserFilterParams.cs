using Common.Query.Filter;

namespace Shop.Query.Users.DTOs.Filter;

public class UserFilterParams : BaseFilterParam
{
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}