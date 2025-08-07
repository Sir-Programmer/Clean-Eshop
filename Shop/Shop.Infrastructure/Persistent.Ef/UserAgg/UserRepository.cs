using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg;

public class UserRepository(ShopContext context) : BaseRepository<User>(context), IUserRepository
{
    
}