using Common.Application.OperationResults;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.DTOs.Filter;

namespace Shop.Presentation.Facade.Sellers;

public interface ISellerFacade
{
    Task<OperationResult<Guid>> Create(CreateSellerCommand command);
    Task<OperationResult> Edit(EditSellerCommand command);
    
    Task<SellerDto?> GetById(Guid id);
    Task<SellerDto?> GetByUserId(Guid userId);
    Task<SellerFilterResult> GetByFilter(SellerFilterParams filters);
}