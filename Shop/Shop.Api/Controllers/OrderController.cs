using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Presentation.Facade.Orders;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.DTOs.Filter;

namespace Shop.Api.Controllers;

public class OrderController(IOrderFacade orderFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<OrderFilterResult?>> GetByFilter([FromQuery] OrderFilterParams filters)
    {
        var result = await orderFacade.GetByFilter(filters);
        return QueryResult(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ApiResult<OrderDto?>> GetById(Guid id)
    {
        var result = await orderFacade.GetById(id);
        return QueryResult(result);
    }

    [HttpGet("current")]
    public async Task<ApiResult<OrderDto?>> GetCurrent()
    {
        var result = await orderFacade.GetCurrentUserOrder(User.GetUserId());
        return QueryResult(result);
    }
}