using Common.Application.OperationResults;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.DTOs.Filter;

namespace Shop.Presentation.Facade.Sellers.Inventories;

public interface ISellerInventoryFacade
{
    Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
    Task<OperationResult> EditInventory(EditSellerInventoryCommand command);
    
    Task<InventoryDto?> GetById(Guid id);
    Task<InventoryDto?> GetByProductId(Guid productId);
    Task<SellerInventoryFilterResult> GetByFilter(SellerInventoryFilterParams filters);
}