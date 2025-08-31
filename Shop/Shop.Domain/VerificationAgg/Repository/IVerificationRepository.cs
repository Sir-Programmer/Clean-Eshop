using Common.Domain.Repository;

namespace Shop.Domain.VerificationAgg.Repository;

public interface IVerificationRepository : IBaseRepository<Verification>
{
    Task<Verification?> GetLastVerificationDataByPhoneNumber(string phoneNumber);
}