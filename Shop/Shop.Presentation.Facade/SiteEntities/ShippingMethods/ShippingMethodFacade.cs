using Common.Application.OperationResults;
using MediatR;
using Shop.Application.SiteEntities.ShippingMethods.Create;
using Shop.Application.SiteEntities.ShippingMethods.Delete;
using Shop.Application.SiteEntities.ShippingMethods.Edit;
using Shop.Query.SiteEntities.DTOs;
using Shop.Query.SiteEntities.ShippingMethods.GetById;
using Shop.Query.SiteEntities.ShippingMethods.GetList;

namespace Shop.Presentation.Facade.SiteEntities.ShippingMethods;

public class ShippingMethodFacade(IMediator mediator) : IShippingMethodFacade
{
    public async Task<OperationResult<Guid>> Create(CreateShippingMethodCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditShippingMethodCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Delete(DeleteShippingMethodCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<ShippingMethodDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetShippingMethodByIdQuery(id));
    }

    public async Task<List<ShippingMethodDto>> GetList()
    {
        return await mediator.Send(new GetShippingMethodListQuery());
    }
}