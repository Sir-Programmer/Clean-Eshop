using Shop.Domain.UserAgg.Enums;

namespace Shop.Api.ViewModels.User;

public class EditUserProfileViewModel
{
    public string Name { get; set; }
    public string Family { get; set; }
    public Gender Gender { get; set; }
}