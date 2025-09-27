using System.Net;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Coupon;
using Shop.Application.Coupons.Create;
using Shop.Application.Coupons.Edit;
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

    [HttpPost]
    public async Task<ApiResult<Guid>> Create(CreateCouponCommand command)
    {
        var result = await couponFacade.Create(command);
        var url = Url.Action("GetById", "Coupon", new { Id = result.Data }, Request.Scheme);
        return CommandResult(result, statusCode: HttpStatusCode.Created, locationUrl: url);
    }

    [HttpPut("{id:guid}")]
    public async Task<ApiResult> Edit(Guid id, EditCouponViewModel vm)
    {
        var result = await couponFacade.Edit(new EditCouponCommand(id, vm.Code, vm.DiscountType, vm.DiscountAmount, vm.ExpirationDate, vm.UsageLimit));
        return CommandResult(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ApiResult> Delete(Guid id)
    {
        var result = await couponFacade.Delete(id);
        return CommandResult(result);
    }
}