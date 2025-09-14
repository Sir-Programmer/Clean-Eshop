using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.SiteEntities.ShippingMethod;
using Shop.Application.SiteEntities.ShippingMethods.Create;
using Shop.Application.SiteEntities.ShippingMethods.Delete;
using Shop.Application.SiteEntities.ShippingMethods.Edit;
using Shop.Presentation.Facade.SiteEntities.ShippingMethods;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Api.Controllers;

public class ShippingMethodController(IShippingMethodFacade shippingMethodFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<List<ShippingMethodDto>>> GetList()
    {
        var result = await shippingMethodFacade.GetList();
        return QueryResult(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ApiResult<ShippingMethodDto?>> GetById(Guid id)
    {
        var result = await shippingMethodFacade.GetById(id);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult<Guid>> Create(CreateShippingMethodCommand command)
    {
        var result = await shippingMethodFacade.Create(command);
        return CommandResult(result);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ApiResult> Create(Guid id, [FromForm] EditShippingMethodViewModel vm)
    {
        var result = await shippingMethodFacade.Edit(new EditShippingMethodCommand(id, vm.Title, vm.Cost));
        return CommandResult(result);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ApiResult> Delete(Guid id)
    {
        var result = await shippingMethodFacade.Delete(new DeleteShippingMethodCommand(id));
        return CommandResult(result);
    }
}