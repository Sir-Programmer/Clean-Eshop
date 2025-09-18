namespace Shop.Api.ViewModels.User;

public class ChangeUserPasswordViewModel
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}