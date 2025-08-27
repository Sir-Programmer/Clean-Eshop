using Common.Application.OperationResults;
using MediatR;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.DTOs.Filter;
using Shop.Query.Sellers.GetByFilter;
using Shop.Query.Sellers.GetById;
using Shop.Query.Sellers.GetByUserId;

namespace Shop.Presentation.Facade.Sellers;

public class SellerFacade(IMediator mediator) : ISellerFacade
{
    public async Task<OperationResult<Guid>> Create(CreateSellerCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditSellerCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<SellerDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetSellerByIdQuery(id));
    }

    public async Task<SellerDto?> GetByUserId(Guid userId)
    {
        return await mediator.Send(new GetSellerByUserIdQuery(userId));
    }

    public async Task<SellerFilterResult> GetByFilter(SellerFilterParams filters)
    {
        return await mediator.Send(new GetSellerByFilterQuery(filters));
    }
}