using Shop.Domain.VerificationAgg.Repository;
using Shop.Domain.VerificationAgg.Services;

namespace Shop.Application.Verifications;

public class VerificationDomainService(IVerificationRepository verificationRepository) : IVerificationDomainService
{
    public bool CheckRateLimit(string phoneNumber)
    {
        return verificationRepository.GetVerificationCountByPhoneNumber(phoneNumber) >= 3;
    }
}