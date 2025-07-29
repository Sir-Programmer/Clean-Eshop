using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Edit;

public class EditRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<EditRoleCommand>
{
    public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetByIdTrackingAsync(request.RoleId);
        if (role == null) return OperationResult.NotFound();
        role.Edit(request.Title);
        var permissions = request.Permissions.Select(p => new RolePermission(p)).ToList();
        role.SetPermissions(permissions);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}