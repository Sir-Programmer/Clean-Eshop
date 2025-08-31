namespace Shop.Domain.VerificationAgg.Services;

public interface IVerificationDomainService
{
    bool CheckRateLimit(string phoneNumber);
}