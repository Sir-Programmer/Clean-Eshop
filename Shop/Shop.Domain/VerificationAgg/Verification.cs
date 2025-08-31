using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.VerificationAgg.Services;

namespace Shop.Domain.VerificationAgg;

public class Verification : AggregateRoot
{
    private Verification() { }
    public Verification(string phoneNumber, string code, IVerificationDomainService  verificationDomainService)
    {
        Guard(phoneNumber, verificationDomainService);
        PhoneNumber = phoneNumber;
        Code = code;
        ExpireTime = DateTime.Now.AddMinutes(5);
        IsUsed = false;
    }
    public string PhoneNumber { get; private set; }
    public string Code { get; private set; }
    public DateTime ExpireTime { get; private set; }
    public bool IsUsed { get; private set; }
    
    
    public bool Verify(string code)
    {
        if (IsUsed || Code != code || ExpireTime < DateTime.Now)
            throw new InvalidDomainDataException("کد اشتباه است یا منقضی شده");
        IsUsed = true;
        return true;
    }

    private void Guard(string phoneNumber, IVerificationDomainService verificationDomainService)
    {
        NullOrEmptyDomainException.CheckString(phoneNumber, nameof(phoneNumber));
        if (!phoneNumber.IsValidIranianPhoneNumber())
            throw new InvalidDomainDataException("شماره موبایل نامعتبر است");
        if (verificationDomainService.CheckRateLimit(phoneNumber))
            throw new InvalidDomainDataException("تعداد درخواست کد شما بیش از حد بوده است لطفا بعد از چند دقیقه مجددا تلاش کنید");
    }
}