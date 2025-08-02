using Common.Application.UnitOfWork;

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