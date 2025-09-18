using Shop.Domain.UserAgg.Enums;

namespace Shop.Api.ViewModels.User
{
    public class EditUserViewModel
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
