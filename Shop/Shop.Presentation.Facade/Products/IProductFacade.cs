using Common.Application.OperationResults;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.EditImageSequence;
using Shop.Application.Products.RemoveImage;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.DTOs.Filter;

namespace Shop.Presentation.Facade.Products;

public interface IProductFacade
{
    Task<OperationResult<Guid>> Create(CreateProductCommand command);
    Task<OperationResult> Edit(EditProductCommand command);
    Task<OperationResult> AddImage(AddProductImageCommand command);
    Task<OperationResult> EditImageSequence(EditProductImageSequenceCommand command);
    Task<OperationResult> RemoveImage(RemoveProductImageCommand command);

    Task<ProductFilterResult> GetByFilter(ProductFilterParams filters);
    Task<ProductShopResult> GetForShop(ProductShopFilterParams filters);
    Task<ProductDto?> GetById(Guid id);
    Task<ProductDto?> GetBySlug(string slug);
    Task<ProductDetailsDto?> GetDetails(string slug);
}