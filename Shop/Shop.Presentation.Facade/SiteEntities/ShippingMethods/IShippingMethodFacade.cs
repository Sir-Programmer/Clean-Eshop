using Common.Application.OperationResults;
using Shop.Application.SiteEntities.ShippingMethods.Create;
using Shop.Application.SiteEntities.ShippingMethods.Delete;
using Shop.Application.SiteEntities.ShippingMethods.Edit;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Presentation.Facade.SiteEntities.ShippingMethods;

public interface IShippingMethodFacade
{
    Task<OperationResult<Guid>> Create(CreateShippingMethodCommand command);
    Task<OperationResult> Edit(EditShippingMethodCommand command);
    Task<OperationResult> Delete(DeleteShippingMethodCommand command);
    
    Task<ShippingMethodDto?> GetById(Guid id);
    Task<List<ShippingMethodDto>> GetList();
}