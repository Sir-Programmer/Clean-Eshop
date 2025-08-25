using Common.Application.OperationResults;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Query.Roles.DTOs;

namespace Shop.Presentation.Facade.Roles;

public interface IRoleFacade
{
    Task<OperationResult<Guid>> Create(CreateRoleCommand command);
    Task<OperationResult> Edit(EditRoleCommand command);
    
    Task<RoleDto?> GetById(Guid id);
    Task<List<RoleDto>> GetAll();
}