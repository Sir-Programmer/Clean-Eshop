using System.Net;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Seller;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Presentation.Facade.Sellers;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.DTOs.Filter;

namespace Shop.Api.Controllers;

public class SellerController(ISellerFacade sellerFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<SellerFilterResult?>> GetByFilter([FromQuery]  SellerFilterParams filters)
    {
        var result = await sellerFacade.GetByFilter(filters);
        return QueryResult(result);
    }
    [HttpGet("{id:guid}")]
    public async Task<ApiResult<SellerDto?>> GetById(Guid id)
    {
        var result = await sellerFacade.GetById(id);
        return QueryResult(result);
    }
    
    [HttpGet("by-user/{userId:guid}")]
    public async Task<ApiResult<SellerDto?>> GetByUserId(Guid userId)
    {
        var result = await sellerFacade.GetByUserId(userId);
        return QueryResult(result);
    }
    
    [HttpPost]
    public async Task<ApiResult<Guid>> Create(CreateSellerCommand command)
    {
        var result = await sellerFacade.Create(command);
        var url = Url.Action("GetById", "Seller", new { id = result.Data }, Request.Scheme);
        return CommandResult(result, statusCode: HttpStatusCode.Created, locationUrl: url);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ApiResult> Edit(Guid id, EditSellerViewModel vm)
    {
        var result = await sellerFacade.Edit(new EditSellerCommand(id, vm.SopName, vm.NationalId));
        return CommandResult(result);
    }
}