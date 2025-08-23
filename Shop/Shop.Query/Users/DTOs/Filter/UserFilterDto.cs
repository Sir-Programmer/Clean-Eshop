using Common.Query;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Query.Users.DTOs.Filter;

public class UserFilterDto : BaseDto
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
}