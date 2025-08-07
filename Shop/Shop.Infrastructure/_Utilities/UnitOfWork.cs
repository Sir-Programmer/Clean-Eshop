using Common.Application.UnitOfWork;
using Shop.Infrastructure.Persistent.Ef;

namespace Shop.Infrastructure._Utilities;

public class UnitOfWork(ShopContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}