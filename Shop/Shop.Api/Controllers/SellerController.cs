using System.Net;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Seller;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Application.Sellers.EditInventory;
using Shop.Presentation.Facade.Sellers;
using Shop.Presentation.Facade.Sellers.Inventories;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.DTOs.Filter;

namespace Shop.Api.Controllers;

public class SellerController(ISellerFacade sellerFacade, ISellerInventoryFacade inventoryFacade) : ApiController
{
    // Seller 
    
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
    
    [HttpGet("me")]
    [Authorize]
    public async Task<ApiResult<SellerDto?>> GetCurrent()
    {
        var result = await sellerFacade.GetByUserId(User.GetUserId());
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
    
    // Seller Inventory

    [HttpGet("inventories")]
    public async Task<ApiResult<SellerInventoryFilterResult?>> GetInventoryByFilter([FromQuery] SellerInventoryFilterParams filters)
    {
        var result = await inventoryFacade.GetByFilter(filters);
        return QueryResult(result);
    }
    
    [HttpGet("me/inventories")]
    [Authorize]
    public async Task<ApiResult<SellerInventoryFilterResult?>> GetCurrentSellerInventory()
    {
        var seller = await sellerFacade.GetByUserId(User.GetUserId());
        if (seller == null) return ApiResult<SellerInventoryFilterResult?>.UnAuthorize(null);
        var result = await inventoryFacade.GetByFilter(new SellerInventoryFilterParams() { SellerId = seller.Id });
        return QueryResult(result);
    }
    
    [HttpGet("inventories/{id:guid}")]
    [Authorize]
    public async Task<ApiResult<InventoryDto?>> GetInventoryById(Guid id)
    {
        var result = await inventoryFacade.GetById(id);
        return QueryResult(result);
    }

    [HttpPost("me/inventories")]
    [Authorize]
    public async Task<ApiResult> AddInventory(AddSellerInventoryViewModel vm)
    {
        var seller = await sellerFacade.GetByUserId(User.GetUserId());
        if (seller == null) return ApiResult.UnAuthorize();
        var result = await inventoryFacade.AddInventory(new AddSellerInventoryCommand(seller.Id, vm.ProductId, vm.Count, vm.Price, vm.DiscountPercentage));
        return CommandResult(result);
    }
    
    [HttpPut("me/inventories/{inventoryId:guid}")]
    [Authorize]
    public async Task<ApiResult> EditInventory(Guid inventoryId,EditSellerInventoryViewModel vm)
    {
        var seller = await sellerFacade.GetByUserId(User.GetUserId());
        if (seller == null) return ApiResult.UnAuthorize();
        var result = await inventoryFacade.EditInventory(new EditSellerInventoryCommand(seller.Id, inventoryId, vm.Count, vm.Price, vm.IsActive, vm.DiscountPercentage));
        return CommandResult(result);
    }
}