using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg;

public class User : AggregateRoot
{
    public User(string name, string family, string phoneNumber, string email, string password, Gender gender, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;

        Roles = [];
        Addresses = [];
        Wallets = [];
    }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Gender Gender { get; private set; }

    public List<UserRole> Roles { get; private set; }
    public List<UserAddress> Addresses { get; private set; }
    public List<UserWallet> Wallets { get; private set; }

    public static User Register(string phoneNumber, string password, IUserDomainService userDomainService)
    {
        return new User("", "", phoneNumber, "", password, Gender.None, userDomainService);
    }
    
    public void Edit(string name, string family, string phoneNumber, string email, Gender gender, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
    }
    
    public void ChangePassword(string newPassword)
    {
        NullOrEmptyDomainException.CheckString(newPassword, nameof(newPassword));

        Password = newPassword;
    }

    public void AddAddress(UserAddress address)
    {
        Addresses.Add(address);
    }

    public void EditAddress(Guid addressId,UserAddress address)
    {
        var oldAddress = Addresses.FirstOrDefault(x => x.Id == addressId);
        if (oldAddress == null) throw new InvalidDomainDataException("آدرس یافت نشد");
        address.Edit(address.Province, address.City, address.PostalCode, address.FullName, address.PostalAddress, address.PhoneNumber, address.NationalId);
    }

    public void RemoveAddress(Guid addressId)
    {
        var address = Addresses.FirstOrDefault(x => x.Id == addressId);
        if (address == null) throw new NullOrEmptyDomainException("آدرس یافت نشد");
        Addresses.Remove(address);
    }

    public void SetActiveAddress(Guid addressId)
    {
        var currentAddress = Addresses.FirstOrDefault(x => x.Id == addressId);
        if (currentAddress == null) throw new InvalidDomainDataException("آدرس یافت نشد");
        Addresses.ForEach(a => a.SetDeActive());
        currentAddress.SetActive();
    }

    public void ChargeWallet(UserWallet wallet)
    {
        wallet.UserId = Id;
        Wallets.Add(wallet);
    }

    public void SetRoles(List<UserRole> roles)
    {
        roles.ForEach(r => r.UserId = Id);
        Roles.Clear();
        Roles.AddRange(roles);
    }

    private void Guard(string phoneNumber, string email, IUserDomainService userDomainService)
    {
        NullOrEmptyDomainException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmptyDomainException.CheckString(email, nameof(email));

        if (!phoneNumber.IsValidIranianPhoneNumber())
            throw new InvalidDomainDataException("شماره موبایل نامعتبر است");
        
        if (!email.IsValidEmail())
            throw new InvalidDomainDataException("ایمیل نامعتبر است");
        
        if (Email != email) 
            if (userDomainService.IsEmailExist(email))
                throw new InvalidDomainDataException("ایمیل از قبل ثبت شده است");
        
        if (PhoneNumber != phoneNumber)
            if (userDomainService.IsPhoneNumberExist(phoneNumber))
                throw new InvalidDomainDataException("شماره موبایل از قبل ثبت شده است");
    }
}