using Common.Application.OperationResults;
using MediatR;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Query.Roles.DTOs;
using Shop.Query.Roles.GetById;
using Shop.Query.Roles.GetList;

namespace Shop.Presentation.Facade.Roles;

public class RoleFacade(IMediator mediator) : IRoleFacade
{
    public async Task<OperationResult<Guid>> Create(CreateRoleCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditRoleCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<RoleDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetRoleByIdQuery(id));
    }

    public async Task<List<RoleDto>> GetAll()
    {
        return await mediator.Send(new GetRoleListQuery());
    }
}