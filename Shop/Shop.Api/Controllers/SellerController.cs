using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
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
}