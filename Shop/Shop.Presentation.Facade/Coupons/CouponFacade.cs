using Common.Application.OperationResults;
using MediatR;
using Shop.Application.Comments.Delete;
using Shop.Application.Coupons.Create;
using Shop.Application.Coupons.Edit;
using Shop.Query.Coupons.DTOs;
using Shop.Query.Coupons.GetByCode;
using Shop.Query.Coupons.GetById;
using Shop.Query.Coupons.GetList;

namespace Shop.Presentation.Facade.Coupons;

public class CouponFacade(IMediator mediator) : ICouponFacade
{
    public async Task<OperationResult<Guid>> Create(CreateCouponCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCouponCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Delete(Guid id)
    {
        return await mediator.Send(new DeleteCommentCommand(id));
    }

    public async Task<CouponDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetCouponByIdQuery(id));
    }

    public async Task<CouponDto?> GetByCode(string code)
    {
        return await mediator.Send(new GetCouponByCodeQuery(code));
    }

    public async Task<List<CouponDto>> GetList()
    {
        return await mediator.Send(new GetCouponListQuery());
    }
}