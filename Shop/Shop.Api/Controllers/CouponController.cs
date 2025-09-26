using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Presentation.Facade.Coupons;
using Shop.Query.Coupons.DTOs;

namespace Shop.Api.Controllers;

public class CouponController(ICouponFacade couponFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<List<CouponDto>>> GetList()
    {
        var result = await couponFacade.GetList();
        return QueryResult(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ApiResult<CouponDto?>> GetById(Guid id)
    {
        var result = await couponFacade.GetById(id);
        return QueryResult(result);
    }

    [HttpGet("code/{code}")]
    public async Task<ApiResult<CouponDto?>> GetById(string code)
    {
        var result = await couponFacade.GetByCode(code);
        return QueryResult(result);
    }
}