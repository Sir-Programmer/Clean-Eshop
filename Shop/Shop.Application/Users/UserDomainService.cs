using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users;

public class UserDomainService(IUserRepository userRepository) : IUserDomainService
{
    public bool IsPhoneNumberExist(string phoneNumber)
    {
        return userRepository.Exists(u => u.PhoneNumber == phoneNumber);
    }

    public bool IsEmailExist(string email)
    {
        return userRepository.Exists(u => u.Email == email);
    }
}