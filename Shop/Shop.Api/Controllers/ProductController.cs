using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModels.Product;
using Shop.Application.Products.Create;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.Products;
using Shop.Query.Products.DTOs.Filter;

namespace Shop.Api.Controllers;

[PermissionChecker(Permission.CrudProduct)]
public class ProductController(IProductFacade productFacade) : ApiController
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<ApiResult<Guid>> CreateProduct([FromForm]CreateProductViewModel viewModel)
    {
        var command = new CreateProductCommand(viewModel.Title, viewModel.Slug, viewModel.Description,
            viewModel.ImageFile, viewModel.SeoData.Map(), viewModel.MainCategoryId, viewModel.GetSubCategories(),
            viewModel.GetSpecification());
        return CommandResult(await productFacade.Create(command));
    }
}