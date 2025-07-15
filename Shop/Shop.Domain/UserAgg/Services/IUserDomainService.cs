namespace Shop.Domain.UserAgg.Services;

public interface IUserDomainService
{
    public bool IsPhoneNumberExist(string phoneNumber);
    public bool IsEmailExist(string email);
}