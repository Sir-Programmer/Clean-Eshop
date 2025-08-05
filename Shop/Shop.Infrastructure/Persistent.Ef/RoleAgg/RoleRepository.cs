using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg;

public class RoleRepository(ShopContext context) : BaseRepository<Role>(context), IRoleRepository
{
    
}