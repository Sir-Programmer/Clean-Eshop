using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Create;

public class CreateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<CreateRoleCommand, Guid>
{
    public async Task<OperationResult<Guid>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role(request.Title);
        var permissions = request.Permissions.Select(p => new RolePermission(p)).ToList();
        role.SetPermissions(permissions);
        await roleRepository.AddAsync(role);
        await unitOfWork.SaveChangesAsync();
        return OperationResult<Guid>.Success(role.Id);
    }
}