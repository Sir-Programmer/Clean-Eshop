using System.Net;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Role;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Presentation.Facade.Roles;
using Shop.Query.Roles.DTOs;

namespace Shop.Api.Controllers;

public class RoleController(IRoleFacade roleFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<List<RoleDto>>> GetList()
    {
        var result = await roleFacade.GetAll();
        return QueryResult(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ApiResult<RoleDto?>> GetById(Guid id)
    {
        var result = await roleFacade.GetById(id);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult<Guid>> Create(CreateRoleCommand command)
    {
        var result = await roleFacade.Create(command);
        var url = Url.Action("GetById", "Role", new { id = result.Data }, Request.Scheme);
        return CommandResult(result, statusCode: HttpStatusCode.Created, locationUrl: url);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ApiResult> Edit(Guid id, EditRoleViewModel vm)
    {
        var result = await roleFacade.Edit(new EditRoleCommand(id, vm.Title, vm.Permissions));
        return CommandResult(result);
    }
}