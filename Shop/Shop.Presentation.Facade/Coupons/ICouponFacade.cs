using Common.Application.OperationResults;
using Shop.Application.Coupons.Create;
using Shop.Application.Coupons.Edit;
using Shop.Query.Coupons.DTOs;

namespace Shop.Presentation.Facade.Coupons;

public interface ICouponFacade
{
    Task<OperationResult<Guid>> Create(CreateCouponCommand command);
    Task<OperationResult> Edit(EditCouponCommand command);
    Task<OperationResult> Delete(Guid id);
    Task<OperationResult> Use(string code);

    Task<CouponDto?> GetById(Guid id);
    Task<CouponDto?> GetByCode(string code);
    Task<List<CouponDto>> GetList();
}