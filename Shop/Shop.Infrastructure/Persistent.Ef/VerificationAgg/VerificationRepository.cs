using Microsoft.EntityFrameworkCore;
using Shop.Domain.VerificationAgg;
using Shop.Domain.VerificationAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.VerificationAgg;

public class VerificationRepository(ShopContext context) : BaseRepository<Verification>(context), IVerificationRepository
{
    public async Task<Verification?> GetLastVerificationDataByPhoneNumber(string phoneNumber)
    {
        return await Context.Verifications.OrderByDescending(v => v.CreationTime).FirstOrDefaultAsync(v => v.PhoneNumber == phoneNumber);
    }

    public async Task<int> GetVerificationCountByPhoneNumber(string phoneNumber)
    {
        return await Context.Verifications.CountAsync(v => v.PhoneNumber == phoneNumber && v.CreationTime >= DateTime.Now.AddMinutes(-30));
    }
}